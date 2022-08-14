import React, { useState, useContext, useEffect } from 'react';
import { AuthContext, queryCurrentUser } from "../UserAuthentication";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import API from "../API";

{/*TODO: Admin can change other users data? (create ProfilePath wrapper for URL and props.user in Profile)*/ }
export default function Profile(props) {
    const authContext = useContext(AuthContext);
    const [pictures, setPictures] = useState([]);

    const onFormSubmit = async (event) => {
        event.preventDefault();

        API.editUser( {
            email: event.target.elements['formEmail'].value,
            firstName: event.target.elements['formFirstName'].value,
            lastName: event.target.elements['formLastName'].value,
            birthdate: event.target.elements['formBirthdate'].value
        }).then((user) => {
            authContext.setUser(user);
        });
    }

    const updatePictures = async () => {
        await API.getUserPictures({
            userId: authContext?.user?.Id,
        }).then((pictures) => {
            setPictures(pictures);
        });
    }

    useEffect(() => {
        const updatePicturesAsync = async () => {
            await updatePictures();
        }
        updatePicturesAsync();
    }, [])

    const removePicture = async (pictureId) => {
        await API.removePicture({
            pictureId: pictureId,
        }).then(() => {
            updatePictures();
        });
    }

    return (
        <div>

            <h3>Profile</h3>
            <Form className="shadow p-3 mb-3" onSubmit={onFormSubmit}>
                {/*TODO: Switch these to FloatingLabels?*/}
                <Form.Group controlId="formEmail">
                    <Form.Label>Email</Form.Label>
                    <Form.Control defaultValue={ authContext?.user?.Email } />
                </Form.Group>
                <Form.Group controlId="formFirstName">
                    <Form.Label>First Name</Form.Label>
                    <Form.Control defaultValue={authContext?.user?.FirstName} />
                </Form.Group>
                <Form.Group controlId="formLastName">
                    <Form.Label>Last Name</Form.Label>
                    <Form.Control defaultValue={authContext?.user?.LastName} />
                </Form.Group>
                <Form.Group controlId="formBirthdate">
                    <Form.Label>Date Of Birth</Form.Label>
                    <Form.Control type="date" paceholder="yyyy/mm/dd" />
                </Form.Group>  
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

                    formData.append("file", file, authContext.user.Email + '/' + file.name);

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
