import React from 'react'

export const CurrentOrderContext = React.createContext();
export const SelectedOrderContext = React.createContext();

export function OrdersProvider({children}){
    const [order,setOrder] = React.useState({idOrder:0});
    const [selOrder,setSelOrder] = React.useState({idOrder:0});

    return(
        <CurrentOrderContext.Provider value={[order,setOrder]}>
            <SelectedOrderContext.Provider value={[selOrder,setSelOrder]}>
                {children}
            </SelectedOrderContext.Provider>
        </CurrentOrderContext.Provider>
    );
}