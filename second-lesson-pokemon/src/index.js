import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import {HashRouter, Route, Routes} from "react-router-dom";
import CardInfo from "./pages/details/components/CardInfo";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <HashRouter basename="/2.2024-Sem-Oris/">
        <Routes>
            <Route path="/2.2024-Sem-Oris/" element={<App />} />
            <Route path="/2.2024-Sem-Oris/poke-info/:name" element={<CardInfo />} />
        </Routes>
    </HashRouter>
);
