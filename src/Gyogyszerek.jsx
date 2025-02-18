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
    <div className="max-w-6xl mx-auto p-6">
      <h1 className="text-3xl font-bold mb-6 text-center text-blue-700">Gyógyszerek listája</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {gyogyszerek.map(gyogyszer => (
          <div key={gyogyszer.Id} className="bg-white p-5 rounded-lg shadow-lg border border-gray-300">
            <h2 className="text-xl font-semibold text-gray-800">{gyogyszer.gyogyszerNev}</h2>
            <p className="text-gray-600 mt-2"><strong>Kategória:</strong> {gyogyszer.kategoria}</p>
            <p className="text-gray-600"><strong>Adagolás:</strong> {gyogyszer.adagolas}</p>
            <p className="text-gray-600"><strong>Kezelési időpont:</strong> {gyogyszer.kezelesiIdopont}</p>
            <p className="text-gray-600"><strong>Emlékeztető:</strong> {gyogyszer.emlekezteto}</p>
            <p className="text-gray-500 italic text-sm"><strong>Megjegyzés:</strong>{gyogyszer.megjegyzes}</p>
          </div>
        ))}
      </div>
    </div>
  );
};
