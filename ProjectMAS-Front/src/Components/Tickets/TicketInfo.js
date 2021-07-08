import React from 'react'
import './TicketInfo.css'
import {UserContext} from '../LogIn/UserContext'
import {SelectedTicketContext} from './TicketsContext'

function TicketInfo(props){
    
    const [user,setUser] = React.useContext(UserContext)
    const [selTicket,setSelTicket] = React.useContext(SelectedTicketContext)

    var style = {
        'margin-left' : '20px',
        'margin-top' : '20px'
    }
    return (
    <div className="ticketinfo">
        <div class="heading">User details</div>
        <div class="tinputt">
            <div className="tinputc">
                <div className="tinput">First Name: {user.name}</div>
                <div className="tinput">Last Name: {user.surname}</div>
                <div className="tinput">Passangers: {selTicket.seatsAmount}</div>
                <div className="tinput">Seats: {selTicket.seat}</div>
            </div>         
            <div className="tinputc">
                <div className="tinput">From: {selTicket.flight.from}</div>
                <div className="tinput">To: {selTicket.flight.to}</div>
                <div className="tinput">Take off: {selTicket.flight.takeOffDate}</div>
                <div className="tinput">Landing: {selTicket.flight.landingDate}</div>
            </div>
            <div className="tinputc" id="1">
                <div className="tinput">Class: {selTicket.class}</div>
                <div className="tinput">Baggage: {selTicket.baggageType === 0?"None":(selTicket.baggageType === 1?"Bagpack":"Large")}</div>
                <div className="tinput">Animals: {selTicket.animals?"True" : "False"}</div>
                <div className="tinput">Additional meal: {selTicket.additonalMeal?"True" : "False"}</div>
            </div>       
        </div>
        <h5 style={style}>Status: {selTicket.approved?"Approved":"Reserved"}</h5>
        <button style={style} type="button" onClick={()=>{props.setPage("ticketsList")}}className="btn btn-danger">Back</button>
    </div>
    );
}

export default TicketInfo;