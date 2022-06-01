import {useState} from "react";
import axios from "axios";
import '../style/FormLogin.css';
import { useNavigate } from "react-router-dom";
import {useAuth} from "../hooks/UserContext";


function FormLogin() {
    const url ="https://localhost:7046/api/login"

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const { login } = useAuth()

    let navigate = useNavigate()

    const handleSubmit = async e => {
        e.preventDefault();
        const userInfo = {
            email,
            password
        };

        await axios.post(
            url,
            userInfo
        ).then(rep => {
            console.log(rep)
            if(rep.status === 200)
            {
                login()
                navigate("/payment")
            }
        }).catch(err => {
            alert("email ou mot de passe eronné")
        })
    }

    return (
        <div className='form card'>
            <h1> Superviseur</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label className="text"> Adresse Email</label>
                    <input placeholder="email" type="email" onChange={({ target }) => setEmail(target.value)} />
                </div>
                <div>
                    <label className="text"> Mot de passe</label>
                <input placeholder="password" type="password" onChange={({ target }) => setPassword(target.value)}/>
                </div>
                <button className="button"> Login</button>
            </form>
        </div>
    )

}

export default FormLogin;