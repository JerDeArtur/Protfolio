import React from 'react';
import { UserContext } from './LogIn/UserContext';
import {CurrentOrderContext} from './Orders/OrdersContext'
function Navbar(props){
    const [user,setUser] = React.useContext(UserContext);
    const [order,setOrder] = React.useContext(CurrentOrderContext)
    var style ={
        'justify-content':'flex-end'
    }
    return(
        <div>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div  className="container-fluid">
                    <a className="navbar-brand" href="#">Navbar</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                    </button>
                    <div style={style} className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                        <a className="nav-link" href="#" onClick={()=>{props.setPage("flightsList")}}>Home</a>
                        </li>
                        <li className="nav-item">
                        <a className="nav-link" href="#" onClick={()=>{props.setPage("ordersList")}} >Orders</a>
                        </li>
                        <li className="nav-item">
                        <a className="nav-link" href="#" onClick={()=>{setOrder({idOrder:0})}} >Create new order</a>
                        </li>
                    </ul>
                    {user.name}
                    </div>
                </div>
            </nav>
        </div>
    );
}

export default Navbar;