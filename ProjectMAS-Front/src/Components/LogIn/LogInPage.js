import React from 'react';
import './LogInPage.css';
import { UserContext } from './UserContext';
import {UserProvider} from './UserContext'
import Button from './Button'

function LogInPage(props){

    const[login,setLogin] = React.useState('');
    const[password,setPassword] = React.useState('');
    const[,setUser] = React.useContext(UserContext);

    function loginHandler(history){
        var url = 'http://localhost:50596/login';
        var request = new XMLHttpRequest();
        request.open('POST', url, true);
        request.setRequestHeader('Content-Type','application/json')
        request.onload = function() {
            setUser(JSON.parse(request.responseText));
            history.push('/flightslist');
        };
        request.onerror = function() {
            alert('Bląd')
        };
        request.send(JSON.stringify({login : login, password : password}))
    }


    return(
        <UserProvider>
        <div className="loginpage">
            <div className="wrapper fiDown">
                <div id="formContent">
                    <form>
                        <input type="text" id="login" className="fi second" name="login" placeholder="Login" value={login} onChange={event=>setLogin(event.target.value)}></input>
                        <input type="text" id="password" className="fi third" name="password" placeholder="Password" value={password} onChange={event=>setPassword(event.target.value)}></input>
                    </form>
                    <Button loginHandler={loginHandler} />  
                    <div id="formFooter">
                        {// eslint-disable-next-line jsx-a11y/anchor-is-valid
                        <a className="underlineHover" href="#">Forgot Password?</a>}
                    </div>
                </div>
            </div>
        </div>
        </UserProvider>
    );
}

export default LogInPage;