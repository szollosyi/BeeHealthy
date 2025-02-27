import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';

export const Gyogyszerek = () => {
  const [gyogyszerek, setGyogyszerek] = useState([]);

  useEffect(() => {
    axios.get(`${API_BASE_URL}GyogyszerAdatok/token`)
      .then(response => {
        console.log(response.data);
        setGyogyszerek(response.data);
      })
      .catch(error => console.error('Hiba történt:', error));
  }, []);

  return (
    <div className="container py-5">
      <h1 className="text-center text-primary fw-bold mb-4">
        <i className="bi bi-capsule-pill"></i> Gyógyszerek listája
      </h1>
      <div className="row g-4">
        {gyogyszerek.map((gyogyszer) => (
          <div key={gyogyszer.Id} className="col-md-6 col-lg-4">
            <div className="card border-0 shadow-lg rounded-lg">
              <div className="card-body p-4 text-center">
                {/* Gyógyszer neve */}
                <h4 className="card-title text-dark fw-bold">
                  <i className="bi bi-capsule"></i> {gyogyszer.gyogyszerNev}
                </h4>

                {/* Kategória badge */}
                <span className="badge bg-info text-white fs-6 px-3 py-2 my-2">
                  <i className="bi bi-tags"></i> {gyogyszer.kategoria}
                </span>

                {/* Megjegyzés */}
                <p className="text-muted fst-italic mt-3">
                  <i className="bi bi-chat-left-text"></i> {gyogyszer.megjegyzes}
                </p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

