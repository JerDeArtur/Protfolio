import React from 'react'
import {UserContext} from '../LogIn/UserContext'
import {FlightSelectorContext} from '../Flights/FlightSelectorContext'
import {CurrentOrderContext} from '../Orders/OrdersContext'

function TicketForm(props){

    const [passangers,setPassangers] = React.useState(1);
    const [clas,setClas] = React.useState('');
    const [baggage,setBaggage] = React.useState(0);
    const [animals,setAnimals] = React.useState(false);
    const [meal,setMeal] = React.useState(false);
    const [seats,setSeats] = React.useState('');
    const [airport,setAirport] = React.useState(0);

    const [user,] = React.useContext(UserContext);
    const [flight,] = React.useContext(FlightSelectorContext)
    const [order,setOrder] = React.useContext(CurrentOrderContext)


    function checkA(event){
        if(animals){
            event.target.style.backgroundColor = 'white'
            event.target.style.color = 'black'
            event.target.firstChild.nodeValue = 'False'
        }else{
            event.target.style.backgroundColor = 'green'
            event.target.style.color = 'white'
            event.target.firstChild.nodeValue = 'True'

        }
        setAnimals(!animals)
    }

    function checkM(event){
        if(meal){
            event.target.style.backgroundColor = 'white'
            event.target.style.color = 'black'
            event.target.firstChild.nodeValue = 'False'

        }else{
            event.target.style.backgroundColor = 'green'
            event.target.style.color = 'white'
            event.target.firstChild.nodeValue = 'True'

        }
        setMeal(!meal)
    }

    function submitHandler(){
        var url = 'http://localhost:50596/ticket';
        var request = new XMLHttpRequest();
        request.open('POST', url, true);
        request.setRequestHeader('Content-Type','application/json')
        request.onload = function() {
            setOrder(JSON.parse(request.responseText));
            props.setPage("flightsList")
        };
        request.onerror = function() {
            alert('Bląd')
        };
        var a = {
            "idPerson":user.idPerson,
            "ticket" : {
                "SeatsAmount" : passangers,
                "Class": clas,
                "BaggageType": baggage,
                "Animals": animals,
                "AdditonalMeal" : meal,
                "Seat" : seats,
                "IdAirport" : airport,
                "IdFlight" : flight.idFlight
            },
            "idOrder" : order.idOrder
        };
        console.log(a);
        request.send(JSON.stringify(a))
    }

    const style = {
        width : '60%',
        'marginLeft' : '10px'
    }
    const style2 = {
        'marginTop' : '20px'
    }

    return(
        <div style={style} className="ticketForm">
            <form className="row g-3">
                <div className="col-md-6">
                    <label className="form-label">Passangers</label>
                    <input type="number" className="form-control" value={passangers} required onChange={event=>setPassangers(event.target.value)}/>
                </div>
                <div className="col-md-6">
                    <label className="form-label">Class</label>
                    <input type="text" className="form-control" value={clas} required onChange={event=>setClas(event.target.value)}/>
                </div>
                <div className="col-md-6">
                    <label className="form-label">Baggage</label>
                    <select className="form-control" value={baggage} onChange={event=>setBaggage(event.target.value)}>
                        <option value="0">Nothing</option>
                        <option value="1">Bagpack</option>
                        <option value="2">Large</option>
                    </select>
                </div>
                <div className="col-md-6">
                        <label className="form-label" htmlFor="flexCheckDefault">Animals</label>
                        <button type="button" className="form-control"  onClick={(event)=>checkA(event)} id="flexCheckDefault">False</button>
                </div>
                <div className="col-md-6">
                        <label className="form-label" htmlFor="flexCheckDefault">Additional meal</label>
                        <button type="button" className="form-control"  onClick={(event)=>checkM(event)} id="flexCheckDefault">False</button>
                </div>
                <div className="col-md-6">
                    <label className="form-label">Seats</label>
                    <input type="text" className=" form-control" required value={seats} onChange={event=>setSeats(event.target.value)}/>
                </div>
                <div className="col-md-6">
                    <label className="form-label">AirportID</label>
                    <input type="number" className="form-control" required value={airport} onChange={event=>setAirport(event.target.value)}/>
                </div>
                <div className="col-md-6">
                </div>
                <div  className="col-md-6">
                    <button style={style2} type="button" onClick={()=>{props.setPage("flightsList")}}className="btn btn-danger">Cancel</button>
                </div>
                <div  className="col-md-6">
                    <button style={style2} type="button" onClick={()=>{submitHandler()}} className="btn btn-primary">Submit</button>
                </div>
            </form>

        </div>
    );
}

export default TicketForm;