import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Lobby from './components/Lobby'
import { HubConnectionBuilder,LogLevel } from '@microsoft/signalr';
import { useState } from 'react';



const App=()=>
{
    const [connection,setConnection]=useState();
    const joinRoom=async(user,room) =>{
        try{
            const connection=new HubConnectionBuilder()
            .withUrl("https://localhost:44345/ChattersHub")
            .configureLogging(LogLevel.Information)
            .build();

            connection.on("ReceiveMessage",(user,message)=>{
                console.log('message received: ',message);
            });

            await connection.start();
            await connection.invoke("JoinRoom",{user,room});  
            setConnection(connection);
        }
        catch(e){
            console.log(e);
        }
    }

    return <div className='app' >
        <h2>Chatter's Chat</h2>
        <hr className='line'/>
        <Lobby joinRoom={joinRoom} />
    </div>
}
export default App;