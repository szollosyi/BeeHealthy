import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';

export const Paciens = () => {
    const [paciensek, setPaciensek] = useState([]);

    useEffect(() => {
        axios.get(`${API_BASE_URL}Paciensek/token`)
            .then(response => {
                console.log(response.data);
                setPaciensek(response.data);
            })
            .catch(error => console.error('Hiba történt:', error));
    }, []);

    return (
        <div className="container mt-4">
      <h2 className="text-success text-center mb-4">
        <i className="bi bi-people"></i> Páciensek
      </h2>
      <table className="table table-hover table-bordered">
        <thead className="table-dark">
          <tr>
            <th>Név</th>
          </tr>
        </thead>
        <tbody>
          {paciensek.map((paciens) => (
            <tr key={paciens.id}>
              <td>
                <i className="bi bi-person-circle"></i> {paciens.nev}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};