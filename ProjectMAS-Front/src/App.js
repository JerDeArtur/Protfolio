import React from 'react';
import {Helmet, HelmetProvider} from 'react-helmet-async'

import LogInPage from './Components/LogIn/LogInPage';
import FligtsList from './Components/Flights/FlightsList';
import Navbar from './Components/Navbar';
import TicketForm from './Components/Tickets/TicketForm';
import OrdersList from './Components/Orders/OrdersList';
import TicketsList from './Components/Tickets/TicketsList';
import TicketInfo from './Components/Tickets/TicketInfo';

import {UserProvider} from './Components/LogIn/UserContext';
import {FlightSelectorProvider} from './Components/Flights/FlightSelectorContext'
import {OrdersProvider} from './Components/Orders/OrdersContext'
import {TicketsProvider} from './Components/Tickets/TicketsContext'

function App() {
  const [page,setPage] = React.useState("login");

  const style = {
    display : 'none',
    colot : 'white'
  }

  return (
    <HelmetProvider>
      <div className="App">
        <Helmet>
          <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
          <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
          <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
          <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
        </Helmet>
        <UserProvider>
          {page === "login" ? (<LogInPage setPage={setPage}/>):(<div style={style}></div>)}
          <OrdersProvider>
            {page !== "login" ? (<Navbar  setPage={setPage} />):(<div style={style}></div>)}
            <FlightSelectorProvider>
              {page === "flightsList" ? (<FligtsList setPage={setPage}/> ):(<div style={style}></div>)}
              {page === "ticketform" ? (<TicketForm setPage={setPage}/>):(<div style={style}></div>)}          
            </FlightSelectorProvider>
            {page === "ordersList" ? (<OrdersList setPage={setPage}/>):(<div style={style}></div>)}
            <TicketsProvider>
              {page === "ticketsList" ? (<TicketsList setPage={setPage}/>):(<div style={style}></div>)}
              {page === "ticketInfo" ? (<TicketInfo setPage={setPage}/>):(<div style={style}></div>)}  
            </TicketsProvider>    
          </OrdersProvider>  
        </UserProvider>
      </div>
    </HelmetProvider>
  );
}

export default App;
