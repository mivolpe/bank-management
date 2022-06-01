import {Navigate} from "react-router-dom";
import {useAuth} from "../hooks/UserContext";
import {useEffect, useState} from "react";
import axios from "axios";

function ClientList () {

    const {loggedIn} = useAuth()
    const [clients, setClients] = useState([])
    const url = "https://localhost:7046/api/Client/clients"

    useEffect(() => {
        console.log(loggedIn)
        axios.get(url)
            .then(res => {
                console.log(res.data.value)
                setClients(res.data.value)
            })
    },[])

    return loggedIn ? (
        <div>
            <h1 className="center">Liste des virements</h1>
            <div className="card-container">
                <table className="GeneratedTable">
                    <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Email</th>
                        <th>Role</th>
                    </tr>
                    </thead>
                    <tbody>
                    {clients.map((d, index) =>
                        <tr key={index}>
                            <td>{d.name}</td>
                            <td>{d.email}</td>
                            <td>{d.role}</td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </div>
        </div>
    ):(
        <Navigate to="/" />
    )
}

export default ClientList;