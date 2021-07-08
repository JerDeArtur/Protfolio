import React from 'react'

export const FlightSelectorContext = React.createContext();

export function FlightSelectorProvider({children}){
    const [flight,setFlight] = React.useState({idFlight:0});

    return(
        <FlightSelectorContext.Provider value={[flight,setFlight]}>
            {children}
        </FlightSelectorContext.Provider>
    );
}