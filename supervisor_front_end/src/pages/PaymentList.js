import {useEffect, useState} from "react";
import axios from "axios";
import '../style/PaymentList.css'
import {useAuth} from "../hooks/UserContext";
import {Navigate} from "react-router-dom";
import * as signalR from "@microsoft/signalr";

function PaymentList() {

    const url ="https://localhost:7046/api/Payment/payments"

    const [payments,setPayments] = useState([])
    const [search,setSearch] = useState("")
    const { loggedIn } = useAuth()

    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute:'2-digit' };

    useEffect(() => {
        signalRService()
        axios.get(url)
            .then(res => {
                console.log(res.data.value)
                setPayments(res.data.value)
            })
    },[])

    const formatDate = (date) => {
        const event = new Date(date)
        return event.toLocaleDateString(undefined, options)
    }

    const signalRService = () => {
        let hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7046/hub", {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets
            })
            .build();

        hubConnection.start().then((res) => {
            setInterval(() => {
                hubConnection.invoke("GetAllPayments")
            },8000)

            hubConnection.on("ServerResponse", (test) => {
                setPayments(test)
            })
        }).catch(err => console.log(err))

    }

    return loggedIn ? (
            <div>
                <h1 className="center">Liste des virements</h1>
                <div className="containsearchBar">
                    <input type="text" placeholder="chercher un payement" className="searchBar" onChange={({target}) => setSearch(target.value)}/>
                </div>
                <div className="card-container">
                    <table className="GeneratedTable">
                        <thead>
                            <tr>
                                <th>Transmetteur</th>
                                <th>Numéro du compte</th>
                                <th>Montant</th>
                                <th>Destinataire</th>
                                <th>Numéro du compte</th>
                                <th>Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            {payments.filter(d => d.transmitter.client.name.includes(search) ||
                                d.transmitter.iban.includes(search) ||
                                d.amount.toString().includes(search) ||
                                d.receiver.client.name.includes(search) ||
                                d.receiver.iban.includes(search) ||
                                d.dateTime.includes(search)).map(d => {
                                return (
                                    <tr>
                                        <td>{d.transmitter.client.name}</td>
                                        <td>{d.transmitter.iban}</td>
                                        <td>{d.amount}</td>
                                        <td>{d.receiver.client.name}</td>
                                        <td>{d.receiver.iban}</td>
                                        <td>{formatDate(d.dateTime)}</td>
                                    </tr>
                                )
                            }

                            )}
                        </tbody>
                    </table>
                </div>
            </div>
    ):(
            <Navigate to="/" />
    )

}

export default PaymentList;