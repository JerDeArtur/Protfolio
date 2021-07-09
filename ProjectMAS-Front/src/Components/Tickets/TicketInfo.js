import React from 'react'
import './TicketInfo.css'
import {UserContext} from '../LogIn/UserContext'
import {SelectedTicketContext} from './TicketsContext'
import {Link} from 'react-router-dom'

function TicketInfo(props){
    
    const [user,] = React.useContext(UserContext)
    const [selTicket,] = React.useContext(SelectedTicketContext)

    var style = {
        'marginLeft' : '20px',
        'marginTop' : '20px'
    }
    return (
    <div className="ticketinfo">
        <div className="heading">User details</div>
        <div className="tinputt">
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
        <Link to="/ticketslist" style={{textDecoration : "none"}}>
            <button style={style} type="button" className="btn btn-danger">Back</button>
        </Link>
    </div>
    );
}

export default TicketInfo;