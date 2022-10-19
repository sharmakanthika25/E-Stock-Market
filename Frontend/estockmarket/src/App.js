
import {useState} from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navbar from './Components/navbar';

import About from "./Components/About.js";
import AddStockPrice from './Components/AddStockPrice';
import Alert from './Components/Alert';
import AllCompanyLatestStockPrice from './Components/AllCompanyLatestStockPrice';
import GetCompanyDetails from './Components/GetCompanyDetails';
import RegisterCompany from './Components/RegisterCompany';


function App() {

    const [mode, setMode] = useState('light');
    const [alert, setAlert] = useState(null);
    const backend_url = "https://localhost:44396/"

    const showAlert = (message, type)=>{
        setAlert({
            msg: message,
            type: type
        })
        setTimeout(() =>{
            setAlert(null)},3000)
    }

    const toggleMode = ()=>{
        if(mode === 'light')
        {
            setMode('dark');
            document.body.style.backgroundColor = '#042743';
            showAlert("Dark mode has been enabled", "success");
        }
        else
        {
            setMode('light');
            document.body.style.backgroundColor = 'white';
            showAlert("Light mode has been enabled", "success");
        }
    }

      return (
            <>
            <BrowserRouter>
                <Navbar mode={mode} toggleMode={toggleMode}/>
                <Alert alert={alert}/>
                <Routes>
                    <Route exact path="/" element={<AllCompanyLatestStockPrice mode={mode} url={backend_url} showAlert={showAlert}/>} />
                    <Route exact path="/registerCompany" element={<RegisterCompany mode={mode} url={backend_url} showAlert={showAlert}/>} />
                    <Route exact path="/addStockPrice" element={<AddStockPrice mode={mode} url={backend_url} showAlert={showAlert}/>} />
                    <Route exact path="/getCompanyDetails" element={<GetCompanyDetails mode={mode} url={backend_url} showAlert={showAlert}/>} />
                  
                    <Route exact path="/about" element={<About mode={mode}/>} />
                </Routes>
            </BrowserRouter>
            </>
            )
    }//  <Route exact path="/getCompanyStockDetails" element={<CompanyPricesByDate mode={mode} url={backend_url} showAlert={showAlert}/>} />

export default App;


