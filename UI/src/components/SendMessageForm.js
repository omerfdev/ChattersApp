import { useState } from "react"
import { InputGroup,Form,Button,FormControl } from "react-bootstrap";

const SendMessageForm=({sendMessage})=>{
    const [message,setMessage]=useState("");
    return <Form onSubmit={e=>{
        e.preventDefaukt();
        sendMessage(message);
        setMessage("");
    }}>
        <InputGroup placeholder="message..." onChange={e=>setMessage(e.target.value)} value={message}/>
        <InputGroup.Append>
        <Button variant="primary" type="submit" disabled={!message}>Send
        </Button>
        </InputGroup.Append>
    </Form>
}