import React, { useState, useContext, useEffect } from 'react';
import RichTextEditor from 'react-rte'; // https://github.com/sstur/react-rte
import Modal from 'react-bootstrap/Modal'
import Form from 'react-bootstrap/Form'

export const InputModal = props => {
    const [value, setValue] = useState(RichTextEditor.createValueFromString(props?.input, 'html'));
    const [modalVisible, setModalVisible] = useState(props.visible);

    if (props.visible !== modalVisible) {
        setModalVisible(props.visible);
        setValue(RichTextEditor.createValueFromString(props?.input, 'html'));
    }

    const onChange = (value) => {
        setValue(value);
    };

    const onSubmit = async (event) => {
        event.preventDefault();
        props?.onSubmit(value.toString('html'));
    }

    const toolbarConfig = {
        // Optionally specify the groups to display (displayed in the order listed).
        display: ['INLINE_STYLE_BUTTONS', 'BLOCK_TYPE_BUTTONS', 'LINK_BUTTONS', 'BLOCK_TYPE_DROPDOWN', 'HISTORY_BUTTONS'],
        INLINE_STYLE_BUTTONS: [
            { label: 'Bold', style: 'BOLD', className: 'custom-css-class' },
            { label: 'Italic', style: 'ITALIC' },
            { label: 'Underline', style: 'UNDERLINE' }
        ],
        BLOCK_TYPE_DROPDOWN: [
            { label: 'Normal', style: 'unstyled' },
            { label: 'Heading Large', style: 'header-one' },
            { label: 'Heading Medium', style: 'header-two' },
            { label: 'Heading Small', style: 'header-three' }
        ],
        BLOCK_TYPE_BUTTONS: [
            { label: 'UL', style: 'unordered-list-item' },
            { label: 'OL', style: 'ordered-list-item' }
        ]
    };

    return (
        <Modal show={modalVisible} onHide={props?.onHide} backdrop={false} size="lg">
            <Modal.Header closeButton>
                <Modal.Title>
                    {props?.title}
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form onSubmit={onSubmit}>
                    <input type="submit" id="submitInput" className="d-none" />
                    <Form.Group className="m-2" controlId="formInput">
                        <RichTextEditor
                            className="new-post-editor"
                            value={value}
                            onChange={onChange}
                            toolbarConfig={toolbarConfig}
                            autoFocus />
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <label htmlFor="submitInput" className="btn btn-primary">Submit</label>
            </Modal.Footer>
        </Modal>
    );
}

export default InputModal;