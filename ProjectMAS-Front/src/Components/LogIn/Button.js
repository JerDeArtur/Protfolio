import React from 'react'
import { withRouter } from 'react-router-dom'

class Button1 extends React.Component{
    render(){
        const {history} = this.props;
        return (
            <input type="button" className="fi fourth" onClick={()=>{this.props.loginHandler(history)}} value="Log In"></input>
        )
    }
}
const Button =  withRouter(Button1)
export default Button;