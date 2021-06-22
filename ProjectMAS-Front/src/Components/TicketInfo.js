import React from 'react'
import './TicketInfo.css'

function TicketInfo(props){
    console.log(props.selTicket)
    var style = {
        'margin-left' : '20px',
        'margin-top' : '20px'
    }
    return (
    <div className="ticketinfo">
        <div class="heading">User details</div>
        <div class="tinputt">
            <div className="tinputc">
                <div className="tinput">First Name: {props.user.name}</div>
                <div className="tinput">Last Name: {props.user.surname}</div>
                <div className="tinput">Passangers: {props.selTicket.seatsAmount}</div>
                <div className="tinput">Seats: {props.selTicket.seat}</div>
            </div>         
            <div className="tinputc">
                <div className="tinput">From: {props.selTicket.flight.from}</div>
                <div className="tinput">To: {props.selTicket.flight.to}</div>
                <div className="tinput">Take off: {props.selTicket.flight.takeOffDate}</div>
                <div className="tinput">Landing: {props.selTicket.flight.landingDate}</div>
            </div>
            <div className="tinputc" id="1">
                <div className="tinput">Class: {props.selTicket.class}</div>
                <div className="tinput">Baggage: {props.selTicket.baggageType === 0?"None":(props.selTicket.baggageType === 1?"Bagpack":"Large")}</div>
                <div className="tinput">Animals: {props.selTicket.animals?"True" : "False"}</div>
                <div className="tinput">Additional meal: {props.selTicket.additonalMeal?"True" : "False"}</div>
            </div>       
        </div>
        <h5 style={style}>Status: {props.selTicket.approved?"Approved":"Reserved"}</h5>
        <button style={style} type="button" onClick={()=>{props.setPage("ticketsList")}}className="btn btn-danger">Back</button>
    </div>
    );
}

export default TicketInfo;