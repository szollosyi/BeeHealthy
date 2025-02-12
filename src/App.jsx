import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { Kezdőlap } from './Kezdolap';
import { Gyogyszerek } from './Gyogyszerek';
import { NemTalalt } from './NemTalalt';
import 'bootstrap-icons/font/bootstrap-icons.css';
import 'bootstrap/dist/css/bootstrap.min.css';
 
export const App = () => {
  return (
    <Router>
      <div className="container">
        <nav>
          <ul>
            <li><Link to="/">Kezdőlap</Link></li>
            <li><Link to="/gyogyszerek">Gyógyszerek</Link></li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<Kezdőlap />} />
          <Route path="/gyogyszerek" element={<Gyogyszerek />} />
          <Route path="*" element={<NemTalalt />} />
        </Routes>
      </div>
    </Router>
  );
};