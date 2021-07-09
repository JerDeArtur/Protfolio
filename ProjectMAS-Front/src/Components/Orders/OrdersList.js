import React, { useEffect } from 'react';
import '../Flights/FlightsList.css'
import '../Tickets/TicketInfo.css'
import {UserContext} from '../LogIn/UserContext'
import {SelectedOrderContext} from './OrdersContext'
import {Link} from 'react-router-dom'

function OrdersList(props){
    const [orders,setOrders] = React.useState([])

    const [user,] = React.useContext(UserContext);
    const [,setSelOrder] = React.useContext(SelectedOrderContext);

    useEffect(()=>{
            var url = 'http://localhost:50596/order';
            var request = new XMLHttpRequest();
            request.open('POST', url, true);
            request.setRequestHeader('Content-Type','application/json')
            request.onload = function() {
                setOrders(JSON.parse(request.responseText));
            };
            request.onerror = function() {
                alert('Bląd')
            };
            var a = {
                "idPerson":user.idPerson
            };
            request.send(JSON.stringify(a))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[])

    function selectOrder(event){
        setSelOrder(orders[event.target.id]);
        
    }

    var style1 = {
        display : 'flex',
        'justifyContent' : 'space-between'
    }

    return(
        <div className="orderslist">
            <div className="heading">Orders</div>
            <div className="list-group">
                {orders.map((order,i)=>(
                    <Link to="/ticketslist" style={{textDecoration : "none"}}>
                        <button key={order.idOrder} style={style1} type="button" onClick={(event)=>{selectOrder(event)}} id={i} className="list-group-item list-group-item-action">
                        Order ID: {order.idOrder}      Created: {order.creationDate}      Payed: {order.payed?"True" : "False"}      Price: {order.totalPrice}
                        </button>
                    </Link>
                ))}
            </div>
        </div>
    );
}

export default OrdersList;