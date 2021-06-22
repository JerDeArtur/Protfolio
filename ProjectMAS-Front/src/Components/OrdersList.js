import React, { useEffect } from 'react';
import './FlightsList.css'
import './TicketInfo.css'
function OrdersList(props){

    const [orders,setOrders] = React.useState([])

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
                "idPerson":props.user.idPerson
            };
            request.send(JSON.stringify(a))
    },[props.page])

    function selectOrder(event){
        props.setSelOrder(orders[event.target.id]);
        props.setPage("ticketsList");
        
    }

    

    var style1 = {
        display : 'flex',
        'justify-content' : 'space-between'
    }


    var op = [];
    for (var i = 0; i < orders.length; i++) {
        op.push(<div><button style={style1} type="button" onClick={(event)=>{selectOrder(event)}} id={i} className="list-group-item list-group-item-action">
            Order ID: {orders[i].idOrder}      Created: {orders[i].creationDate}      Payed: {orders[i].payed?"True" : "False"}      Price: {orders[i].totalPrice}
            </button>
</div>);
    }



    return(
        <div className="orderslist">

        <div class="heading">Orders</div>
            <div className="list-group">
                {op}
            </div>
        </div>
    );
}

export default OrdersList;