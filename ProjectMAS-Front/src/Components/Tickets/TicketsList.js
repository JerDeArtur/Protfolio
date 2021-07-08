import React, { useEffect } from 'react';
import '../Flights/FlightsList.css'
import {UserContext} from '../LogIn/UserContext'
import {CurrentOrderContext,SelectedOrderContext} from '../Orders/OrdersContext'
import {SelectedTicketContext} from './TicketsContext'
function TicketsList(props){

    const [tickets,setTickets] = React.useState([])
    const [user,setUser] = React.useContext(UserContext)
    const [order,setOrder] = React.useContext(CurrentOrderContext)
    const [selOrder,setSelOrder] = React.useContext(SelectedOrderContext)
    const [selTicket,setSelTicket] = React.useContext(SelectedTicketContext)

    useEffect(()=>{
            var url = 'http://localhost:50596/ticket/get';
            var request = new XMLHttpRequest();
            request.open('POST', url, true);
            request.setRequestHeader('Content-Type','application/json')
            request.onload = function() {
                setTickets(JSON.parse(request.responseText));
            };
            request.onerror = function() {
                alert('Bląd')
            };
            var a = {
                "idPerson": user.idPerson,
                "idOrder" : selOrder.idOrder
            };
            request.send(JSON.stringify(a))
    },[selOrder,user.idPerson])

    function selectTicket(event){
        setSelTicket(tickets[event.target.id]);
        props.setPage("ticketInfo");        
    }

    function pay(event,path){
        var url = 'http://localhost:50596/order/'+path;
            var request = new XMLHttpRequest();
            request.open('POST', url, true);
            request.setRequestHeader('Content-Type','application/json')
            request.onload = function() {
                if(request.status === 404)
                    alert("Already payed")
                else{
                    if(order.idOrder === selOrder.idOrder)
                        setOrder({idOrder:0})
                }
            };
            request.onerror = function() {
                alert('Bląd')
            };
            var a = {
                "idPerson":user.idPerson,
                "idOrder" : selOrder.idOrder
            };
            request.send(JSON.stringify(a))
    }

    var op = [];
    for (var i = 0; i < tickets.length; i++) {
        op.push(<button type="button" onClick={(event)=>{selectTicket(event)}} id={i} className="list-group-item list-group-item-action">
            Ticket ID: {tickets[i].idTicket}      Passangers: {tickets[i].seatsAmount}      Approved: {tickets[i].approved?"True" : "False"}      Price: {tickets[i].flight.price}</button>);
    }

    var style = {
        'margin-left' : '20px',
        'margin-top' : '20px',
        'margin-bottom' : '20px'
    }

    var style2 = {
        'margin-right':'20px',
        'margin-left':'20px'
    }

    return(
        <div className="ticketslist">
                         <div class="heading">Order details</div>
        <div class="tinputt">
            <div className="tinputc">
                <div className="tinput">First Name: {user.name}</div>
                <div className="tinput">Last Name: {user.surname}</div>
                <div className="tinput">Created: {selOrder.creationDate}</div>
            </div>     
        </div>
        <div >
            <a style={style2} href="#" onClick={(event)=>{pay(event,'reserve')}}>Reserve</a>
            <a href="#" onClick={(event)=>{pay(event,'fully')}}>Pay Fully</a>
        </div>
        <h5 style={style}>Status: {selOrder.payed?"Payed":"Not payed"}</h5>
        <br/>
        <div class="heading">Tickets</div>
            <div className="list-group">
                {op}
            </div>
        </div>
    );
}

export default TicketsList;