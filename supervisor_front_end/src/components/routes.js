import {BrowserRouter, Route, Routes} from "react-router-dom";
import NavBar from "./NavBar";
import PaymentList from "../pages/PaymentList";
import FormLogin from "../pages/FormLogin";
import ClientList from "../pages/ClientList";

export const AuthenticatedRoutes = () => {
    return (
        <BrowserRouter>
            <NavBar/>
            <Routes>
                <Route path="/payment" element={ <PaymentList/>}/>
                <Route path="/client" element={ <ClientList/>}/>
                <Route path="/" element={<FormLogin />}/>
            </Routes>
        </BrowserRouter>
    )
}
