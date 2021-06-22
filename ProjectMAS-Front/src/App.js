import React from 'react';
import LogInPage from './Components/LogInPage';
import FligtsList from './Components/FlightsList';
import { Helmet } from 'react-helmet'
import Navbar from './Components/Navbar';
import TicketForm from './Components/TicketForm';
import OrdersList from './Components/OrdersList';
import TicketsList from './Components/TicketsList';
import TicketInfo from './Components/TicketInfo';

function App() {
  const [page,setPage] = React.useState("login");
  const [user,setUser] = React.useState({
    contactData: null,
    employments: null,
    idCD: 0,
    idEmp: 0,
    idPerson: 0,
    idType: 0,
    login: "",
    logined: true,
    mechanik: null,
    name: "",
    orders: null,
    password: "",
    pesel: null,
    pilot: null,
    salary: null,
    staff: null,
    surname: ""}
  );
  const [order,setOrder] = React.useState({idOrder:0});
  const [flight,setFlight] = React.useState({idFlight:0});
  const [selOrder,setSelOrder] = React.useState({idOrder:0});
  const [selTicket,setSelTicket] = React.useState({idOrder:0});




  const style = {
    display : 'none',
    colot : 'white'
  }
  return (
    <div className="App">
      <Helmet>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"></link>
        <script>
            window.$ = window.jQuery = require('jquery');
            window.Bootstrap = require('bootstrap');
        </script>
      </Helmet>
      {page !== "login" ? (<Navbar user={user} setPage={setPage} setOrder={setOrder}/>):(<div style={style}></div>)}
      {page === "login" ? (<LogInPage setPage={setPage} setUser={setUser}/>):(<div style={style}></div>)}
      {page === "flightsList" ? (<FligtsList page={page} setPage={setPage} user={user} setFlight={setFlight}/> ):(<div style={style}></div>)}
      {page === "ticketform" ? (<TicketForm setPage={setPage} user={user} flight={flight} setOrder={setOrder} order={order} setSelOrder={setSelOrder}/>):(<div style={style}></div>)}
      {page === "ordersList" ? (<OrdersList setPage={setPage} user={user} selOrder={selOrder} setSelOrder={setSelOrder}/>):(<div style={style}></div>)}
      {page === "ticketsList" ? (<TicketsList setPage={setPage} user={user} setOrder={setOrder} selOrder={selOrder} setSelTicket={setSelTicket}/>):(<div style={style}></div>)}
      {page === "ticketInfo" ? (<TicketInfo setPage={setPage} selTicket={selTicket} user={user}/>):(<div style={style}></div>)}
    </div>
  );
}

export default App;
