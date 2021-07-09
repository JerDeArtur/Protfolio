import React from 'react';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'

import LogInPage from './Components/LogIn/LogInPage';
import FlightsList from './Components/Flights/FlightsList';
import Navbar from './Components/Navbar';
import TicketForm from './Components/Tickets/TicketForm';
import OrdersList from './Components/Orders/OrdersList';
import TicketsList from './Components/Tickets/TicketsList';
import TicketInfo from './Components/Tickets/TicketInfo';

import {UserProvider} from './Components/LogIn/UserContext';
import {FlightSelectorProvider} from './Components/Flights/FlightSelectorContext'
import {OrdersProvider} from './Components/Orders/OrdersContext'
import {TicketsProvider} from './Components/Tickets/TicketsContext'

function Content(){
  return(
    <OrdersProvider>
      <Navbar/>
        <FlightSelectorProvider>
          <Route exact path="/flightslist" component={FlightsList}/>
          <Route exact path="/ticketform" component={TicketForm}/>
        </FlightSelectorProvider>
        <Route exact path="/orderslist" component={OrdersList}/>
        <TicketsProvider>
          <Route exact path="/ticketslist" component={TicketsList}/>
          <Route exact path="/ticketinfo" component={TicketInfo}/>
        </TicketsProvider>
    </OrdersProvider>
  )
}
function App() {

  return (
    <Router>
      <div className="App">
        <UserProvider>
          <Switch>
            <Route exact path="/login" component={LogInPage}/>
            <Route path="/" component={Content}/>
          </Switch>  
         </UserProvider>
       </div>
    </Router>
  );
}

export default App;
