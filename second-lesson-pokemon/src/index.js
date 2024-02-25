import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import {BrowserRouter, HashRouter, Route, Routes} from "react-router-dom";
import CardInfo from "./pages/details/components/CardInfo";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <BrowserRouter basename={process.env.PUBLIC_URL}>
        <Routes>
            <Route path={`${process.env.PUBLIC_URL}`} element={<App />} />
            <Route path={`${process.env.PUBLIC_URL}/poke-info/:name`} element={<CardInfo />} />
        </Routes>
    </BrowserRouter>
);
