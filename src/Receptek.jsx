import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';

export const Receptek = () => {
    const [receptek, setReceptekList] = useState([]);

    useEffect(() => {
        axios.get(`${API_BASE_URL}ReceptekDTO/token`)
            .then(response => {
                console.log(response.data);
                setReceptekList(response.data);
            })
            .catch(error => console.error('Hiba történt:', error));
    }, []);

    return(
        <div className="container mt-4">
      <h2 className="text-primary text-center mb-4">
        <i className="bi bi-prescription"></i> Receptek
      </h2>
      <div className="row">
        {receptek.map((recept) => (
          <div className="col-md-6" key={recept.id}>
            <div className="card shadow-sm mb-4">
              <div className="card-body">
                <h5 className="card-title text-success">
                  <i className="bi bi-file-earmark-medical"></i> Recept: {recept.paciensNev}
                </h5>
                <ul className="list-group list-group-flush">
                  <li className="list-group-item">
                    <i className="bi bi-person me-2 text-info"></i>
                    <strong>Páciens Név:</strong> {recept.paciensNev}
                  </li>
                  <li className="list-group-item">
                    <i className="bi bi-capsule me-2 text-danger"></i>
                    <strong>Gyógyszer Név:</strong> {recept.gyogyszerNev}
                  </li>
                  <li className="list-group-item">
                    <i className="bi bi-person-badge me-2 text-warning"></i>
                    <strong>Orvos Név:</strong> {recept.orvosNev}
                  </li>
                  <li className="list-group-item">
                    <i className="bi bi-calendar-event me-2 text-primary"></i>
                    <strong>Kezelési Időpont:</strong> {recept.kezelesiIdopont}
                  </li>
                  <li className="list-group-item">
                    <i className="bi bi-calendar-check me-2 text-success"></i>
                    <strong>Kezelés Kezdete:</strong> {recept.kezelesKezdete.split('T')[0]}
                  </li>
                  <li className="list-group-item">
                    <i className="bi bi-calendar-x me-2 text-danger"></i>
                    <strong>Kezelés Vége:</strong> {recept.kezelesVege.split('T')[0]}
                  </li>
                  <li className="list-group-item">
                    <i className="bi bi-capsule-pill me-2 text-secondary"></i>
                    <strong>Adagolás:</strong> {recept.adagolas}
                  </li>
                </ul>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
    );
}