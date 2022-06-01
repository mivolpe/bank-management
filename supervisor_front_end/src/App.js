import './style/App.css'
import {useAuth} from "./hooks/UserContext";
import {AuthenticatedRoutes, UnauthenticatedRoutes} from "./components/routes";

function App() {

    return  <AuthenticatedRoutes/>
}

export default App;
