import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import {HashRouter, Route, Routes} from "react-router-dom";
import CardInfo from "./pages/details/components/CardInfo";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <HashRouter basename={process.env.PUBLIC_URL}>
        <Routes>
            <Route path="/" element={<App />} />
            <Route path="/poke-info/:name" element={<CardInfo />} />
        </Routes>
    </HashRouter>
);
