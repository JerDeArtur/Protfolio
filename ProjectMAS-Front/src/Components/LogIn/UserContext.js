import React from 'react';

export const UserContext = React.createContext();

export function UserProvider({children}){
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

      return (
      <UserContext.Provider value={[user,setUser]}>
            {children}
      </UserContext.Provider>
      )
}