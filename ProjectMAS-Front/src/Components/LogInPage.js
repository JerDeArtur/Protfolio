import React from 'react';
import './LogInPage.css';
function LogInPage(props){

    const[login,setLogin] = React.useState('');
    const[password,setPassword] = React.useState('');

    function loginHandler(){
        var url = 'http://localhost:50596/login';
        var request = new XMLHttpRequest();
        request.open('POST', url, true);
        request.setRequestHeader('Content-Type','application/json')
        request.onload = function() {
            props.setUser(JSON.parse(request.responseText));
            props.setPage("flightsList")
        };
        request.onerror = function() {
            alert('Bląd')
        };
        request.send(JSON.stringify({login : login, password : password}))
    }
        

    return(
        <div className="loginpage">
            <div className="wrapper fiDown">
                <div id="formContent">
                    <form>
                        <input type="text" id="login" className="fi second" name="login" placeholder="Login" value={login} onChange={event=>setLogin(event.target.value)}></input>
                        <input type="text" id="password" className="fi third" name="password" placeholder="Password" value={password} onChange={event=>setPassword(event.target.value)}></input>
                        <input type="button" className="fi fourth" onClick={loginHandler} value="Log In"></input>
                    </form> 
                    <div id="formFooter">
                        <a className="underlineHover" href="#">Forgot Password?</a>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default LogInPage;