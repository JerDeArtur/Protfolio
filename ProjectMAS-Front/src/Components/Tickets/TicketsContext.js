import React from 'react'

export const SelectedTicketContext = React.createContext();

export function TicketsProvider({children}){
    const [selTicket,setSelTicket] = React.useState({idOrder:0});

    return(
        <SelectedTicketContext.Provider value={[selTicket,setSelTicket]}>
            {children}
        </SelectedTicketContext.Provider>
    )
}