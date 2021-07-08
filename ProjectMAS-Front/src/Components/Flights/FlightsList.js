import React, { useEffect } from 'react';
import './FlightsList.css'
import {FlightSelectorContext} from '../Flights/FlightSelectorContext'
function FlightsList(props){

    const [flights,setFlights] = React.useState([])
    const [from,setFrom] = React.useState('');
    const [to,setTo] = React.useState('');
    const [date,setDate] = React.useState('');
    const [update,setUpdate] = React.useState({})

    const [,setFlight] = React.useContext(FlightSelectorContext)

    useEffect(()=>{
        fetch("http://localhost:50596/flights?from="+from+"&to="+to+"&date="+date).then(res => res.json())
        .then(body => {setFlights(body);}); 
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[update])

    function selectFlight(event){
        if(window.confirm("Are you sure?")){
            setFlight(flights[event.target.id]);
            props.setPage("ticketform");
        }
    }

    var op = [];
    for (var i = 0; i < flights.length; i++) {
        op.push(<button key={flights[i].idFlight} type="button" onClick={(event)=>{selectFlight(event)}} id={i} className="list-group-item list-group-item-action">From: {flights[i].from}      To: {flights[i].to}      TakeOff: {flights[i].takeOffDate}      Landing: {flights[i].landingDate}      Price: {flights[i].price}</button>);
    }

    return(
        <div className="flightslist">
            <section className="search-sec">
                <div className="container">
                    <form action="#" method="post" noValidate="novalidate">
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="row">
                                    <div className="col-lg-3 col-md-3 col-sm-12 p-0">
                                        <input type="text" name="from" className="form-control search-slt" value={from} onChange={event=>setFrom(event.target.value)} placeholder="From"/>
                                    </div>
                                    <div className="col-lg-3 col-md-3 col-sm-12 p-0">
                                        <input type="text" name="to" className="form-control search-slt" value={to} onChange={event=>setTo(event.target.value)} placeholder="To"/>
                                    </div>
                                    <div className="col-lg-3 col-md-3 col-sm-12 p-0">
                                        <input type="date" name="date" className="form-control search-slt" value={date} onChange={event=>setDate(event.target.value) } placeholder="Date"/>
                                    </div>
                                    <div className="col-lg-3 col-md-3 col-sm-12 p-0">
                                        <button type="button" className="btn btn-primary wrn-btn" onClick={()=>{setUpdate({})}}>Search</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </section>
            <div className="list-group">
                {op}
            </div>
        </div>
    );
}

export default FlightsList;