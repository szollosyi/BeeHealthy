import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';

export const Orvosok = () => {
    const [orvosList, setOrvosList] = useState([]);

    useEffect(() => {
        axios.get(`${API_BASE_URL}Orvos/token`)
            .then(response => {
                console.log(response.data);
                setOrvosList(response.data);
            })
            .catch(error => console.error('Hiba történt:', error));
    }, []);
    return (
        <div className="container mt-4">
          <h2 className="text-primary text-center mb-4">
            <i className="bi bi-heart-pulse"></i> Orvosok
          </h2>
          <div className="row">
            {orvosList.map((orvos) => (
              <div key={orvos.id} className="col-md-6">
                <div className="card shadow-sm mb-3">
                  <div className="card-body text-center">
                    <i className="bi bi-person-badge fs-1 text-secondary"></i>
                    <h5 className="card-title mt-2">{orvos.nev}</h5>
                    <p className="card-text text-muted">{orvos.beosztas}</p>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
    );
};