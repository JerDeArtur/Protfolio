import React from 'react';
import { UserContext } from './LogIn/UserContext';
import {CurrentOrderContext} from './Orders/OrdersContext'
import {Link} from 'react-router-dom'
function Navbar(props){
    const [user,] = React.useContext(UserContext);
    const [,setOrder] = React.useContext(CurrentOrderContext)
    var style ={
        'justifyContent':'flex-end'
    }
    return(
        <div>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div  className="container-fluid">
                    {// eslint-disable-next-line jsx-a11y/anchor-is-valid
                    <a className="navbar-brand" href="#">Ticket Shop</a>}
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                    </button>
                    <div style={style} className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                        <Link to="/flightslist" className="nav-link" >Home</Link>
                        </li>
                        <li className="nav-item">
                        <Link to="/orderslist" className="nav-link"  >Orders</Link>
                        </li>
                        <li className="nav-item">
                        {// eslint-disable-next-line jsx-a11y/anchor-is-valid
                        <a className="nav-link" href="#" onClick={()=>{setOrder({idOrder:0})}} >Create new order</a>}
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