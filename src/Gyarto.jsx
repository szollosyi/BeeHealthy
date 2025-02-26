import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';

export const Gyartok = () => {
    const [gyartokList, setGyartokList] = useState([]);

    useEffect(() => {
        axios.get(`${API_BASE_URL}Gyarto/token`)
            .then(response => {
                console.log(response.data);
                setGyartokList(response.data);
            })
            .catch(error => console.error('Hiba történt:', error));
    }, []);

    return (
        <div className="container mt-4">
          <h2 className="text-warning text-center mb-4">
            <i className="bi bi-building"></i> Gyártók
          </h2>
          <div className="row">
            {gyartokList.map((gyarto) => (
              <div key={gyarto.id} className="col-md-6">
                <div className="card border-warning shadow-sm mb-3">
                  <div className="card-body">
                    <h5 className="card-title text-dark">
                      <i className="bi bi-briefcase-fill"></i> {gyarto.nev}
                    </h5>
                    <h6 className="card-subtitle mb-2 text-muted">
                      <i className="bi bi-geo-alt"></i> {gyarto.cim}
                    </h6>
                    <p className="card-text text-secondary">{gyarto.leiras}</p>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
    );
};