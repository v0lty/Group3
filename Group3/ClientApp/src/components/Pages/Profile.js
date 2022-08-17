import React, { useState, useContext, useEffect } from 'react';
import { AuthContext, queryCurrentUser } from "../UserAuthentication";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import API from "../API";
import { useParams } from 'react-router';
import { useHistory } from "react-router-dom";
import moment from "moment";
import FloatingLabel from 'react-bootstrap/FloatingLabel';

export const ProfilePath = () => {
    const authContext = useContext(AuthContext);
    const { id } = useParams();
    const history = useHistory();
    const [user, setUser] = useState(null);
    
    const updateUser = () => {

        if (authContext?.user?.HasAuthority != true && authContext?.user?.Id != id) {
            console.log(authContext?.user);
            alert("Access denied!");
            return;
        }

        API.getUserById({
            userId: id
        }).then((user) => {
            setUser(user);
        });
    };

    useEffect(() => {
        updateUser();
    }, [id])

    return (
        <div>
            <Profile user={user} />
        </div>
    );
}

export const Profile = props => {
    const authContext = useContext(AuthContext);
    const [pictures, setPictures] = useState([]);
    const [date, setDate] = useState("YYYY-MM-DD");

    const onFormSubmit = async (event) => {
        event.preventDefault();

        API.editUser( {
            email: event.target.elements['emailInput'].value,
            firstName: event.target.elements['firstNameInput'].value,
            lastName: event.target.elements['lastNameInput'].value,
            birthdate: event.target.elements['birthdateInput'].value
        }).then((user) => {
        });
    }

    const updatePictures = async () => {
        await API.getUserPictures({
            userId: props?.user?.Id,
        }).then((pictures) => {
            setPictures(pictures);
        });
    }

    useEffect(() => {
        updatePictures();
        setDate(moment(props?.user?.Birthdate).format('YYYY-MM-DD'));
    }, [props])

    const removePicture = async (pictureId) => {
        await API.removePicture({
            pictureId: pictureId,
        }).then(() => {
            updatePictures();
        });
    }

    const dateFromDateString = (dateString) => {
        return moment(new Date(dateString)).format('YYYY-MM-DDT00:00:00.000');
    };

    const dateForPicker = (dateString) => {
        return moment(new Date(dateString)).format('YYYY-MM-DD')
    };

    return (
        <div>
            <h3>Profile</h3>
            <Form className="shadow p-3 mb-3" onSubmit={onFormSubmit}>
                <FloatingLabel label="Email" className="mb-3">
                    <Form.Control type="email" defaultValue={props?.user?.Email} id="emailInput" />
                </FloatingLabel>
                <FloatingLabel label="First Name" className="mb-3">
                    <Form.Control type="text" defaultValue={props?.user?.FirstName} id="firstNameInput" />
                </FloatingLabel>
                <FloatingLabel label="Last Name" className="mb-3">
                    <Form.Control type="text" defaultValue={props?.user?.LastName} id="lastNameInput" />
                </FloatingLabel>
                <FloatingLabel label="Date Of Birth" className="mb-3">
                    <Form.Control type="date" value={date ? dateForPicker(date) : ''}
                        placeholder={date ? dateForPicker(date) : "dd/mm/yyyy"}
                        onChange={(e) => setDate(dateFromDateString(e.target.value))} id="birthdateInput" />
                </FloatingLabel>
                <Button className="mt-3" type="submit">Save</Button>
            </Form>

            <h3>Gallery</h3>
            <div className="shadow p-3">
                <div className="d-flex">
                    {pictures?.map((picture, pictureIndex) =>
                        <div key={pictureIndex}>
                            <img className="profile-picture p-2" src={`../Pictures/${picture.Path}`}></img>
                            <a onClick={() => removePicture(picture.Id)}>X</a>
                        </div>
                    )}
                </div>
                <input type="file" name="imageInput" onChange={(event) => {

                    const file = event.target.files[0];
                    const formData = new FormData();
                    formData.append("file", file, props?.user?.Email + '/' + file.name);

                    API.uploadFile(formData)
                        .then((picture) => {
                            updatePictures();
                        });
                    }}
                />
            </div>
        </div>
    );
}
