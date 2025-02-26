import React, { createContext, useContext, useState, useEffect } from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import { Kezdőlap } from './Kezdolap';
import { Gyogyszerek } from './Gyogyszerek';
import { NemTalalt } from './NemTalalt';
import { Login } from './Login';
import {Paciens} from './Paciens';
import { Orvosok } from './Orvosok';
import {Gyartok} from './Gyarto';
import { Registratio } from './Registratio';
import ReactSwitch from 'react-switch';  // Importáljuk a React Switch könyvtárat

// Context létrehozása a sötét mód kezelésére
const ThemeContext = createContext();

const ThemeProvider = ({ children }) => {
  const [darkMode, setDarkMode] = useState(localStorage.getItem("theme") === "dark");

  useEffect(() => {
    if (darkMode) {
      document.documentElement.classList.add("dark");
      localStorage.setItem("theme", "dark");
    } else {
      document.documentElement.classList.remove("dark");
      localStorage.setItem("theme", "light");
    }
  }, [darkMode]);

  return (
    <ThemeContext.Provider value={{ darkMode, setDarkMode }}>
      {children}
    </ThemeContext.Provider>
  );
};

const useTheme = () => useContext(ThemeContext);

const DarkModeToggle = () => {
  const { darkMode, setDarkMode } = useTheme();

  return (
    <div className="d-flex align-items-center ms-3">
      <span className="text-white me-2">{darkMode ? "🌙" : "☀️"}</span>
      <ReactSwitch
        checked={darkMode}
        onChange={() => setDarkMode(!darkMode)}
        onColor="#4b4b4b"
        offColor="#f5f5f5"
        handleDiameter={30}
        uncheckedIcon={false}
        checkedIcon={false}
        height={20}
        width={48}
        className="react-switch"
      />
    </div>
  );
};

export const App = () => {
  return (
    <ThemeProvider>
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary shadow">
        <div className="container">
          <Link className="navbar-brand fw-bold" to="/">
            <i className="bi bi-capsule"></i> BeeHealthy
          </Link>
          <button className="navbar-toggler ms-auto" type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNav"
            aria-controls="navbarNav"
            aria-expanded="false"
            aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav ms-auto">
              <li className="nav-item">
                <Link className="nav-link" to="/">Kezdőlap</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/gyogyszerek">Gyógyszerek</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/Paciens">Páciensek</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/Orvosok">Orvosok</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/Gyarto">Gyártók</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/registratio">Regisztráció</Link>
              </li>
            </ul>
            <button 
              className="btn btn-light ms-3"> 
              <Link className="nav-link" to="/login">
                <i className="bi bi-person-circle" style={{ fontSize: '24px' }}></i>
              </Link>
            </button>
            {/* Dark Mode Toggle Button with Switch */}
            <DarkModeToggle />
          </div>
        </div>
      </nav>

      <div className="container mt-4">
        <Routes>
          <Route path="/" element={<Kezdőlap />} />
          <Route path="/gyogyszerek" element={<Gyogyszerek />} />
          <Route path="/login" element={<Login />} />
          <Route path='/Paciens' element={<Paciens />} />
          <Route path='/Orvosok' element={<Orvosok />} />
          <Route path='/Gyarto' element={<Gyartok />} />
          <Route path="/registratio" element={<Registratio />} />
          <Route path="*" element={<NemTalalt />} />
        </Routes>
      </div>
    </ThemeProvider>
  );
};