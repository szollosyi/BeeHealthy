import React from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import { Kezdőlap } from './Kezdolap';
import { Gyogyszerek } from './Gyogyszerek';
import { NemTalalt } from './NemTalalt';
import 'bootstrap-icons/font/bootstrap-icons.css';
import 'bootstrap/dist/css/bootstrap.min.css';

export const App = () => {
  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary shadow">
        <div className="container">
          <Link className="navbar-brand fw-bold" to="/">
            <i className="bi bi-capsule"></i> BeeHealthy
          </Link>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav ms-auto">
              <li className="nav-item">
                <Link className="nav-link" to="/">Kezdőlap</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/gyogyszerek">Gyógyszerek</Link>
              </li>
            </ul>
            <button 
              className="btn btn-light ms-3">
              <i className="bi bi-person-circle" style={{ fontSize: '24px' }}></i>
            </button>
          </div>
        </div>
      </nav>
      <div className="container mt-4">
        <Routes>
          <Route path="/" element={<Kezdőlap />} />
          <Route path="/gyogyszerek" element={<Gyogyszerek />} />
          <Route path="*" element={<NemTalalt />} />
        </Routes>
      </div>
    </>
  );
};
