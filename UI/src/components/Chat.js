import { Button } from "react-bootstrap";
import MessageContainer from "./MessagesContainer";
import SendMessageForm from "./SendMessageForm";
import ConnectedUsers from "./ConnectedUsers";

const Chat= ({messages,sendMessage,closeConnection,users})=><div>
    <div className="leave-room">
        <Button variant="danger" onClick={()=>closeConnection()}>Leave Room</Button>
    </div>
    <ConnectedUsers users={users} />
    <div className="chat">
        <MessageContainer messages={messages}/>
        <SendMessageForm sendMessage={sendMessage}/>
    </div>
</div>

export default Chat;