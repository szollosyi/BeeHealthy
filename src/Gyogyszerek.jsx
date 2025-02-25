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
  <h1 className="text-3xl font-bold mb-6 text-center text-blue-700 dark:text-blue-400">
    Gyógyszerek listája
  </h1>
  <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
    {gyogyszerek.map(gyogyszer => (
      <div
        key={gyogyszer.Id}
        className="bg-white p-5 rounded-lg shadow-lg border border-gray-300 dark:bg-gray-800 dark:border-gray-600"
      >
        <h2 className="text-xl font-semibold text-gray-800 dark:text-gray-100" id='fekete'>
         {gyogyszer.gyogyszerNev}
        </h2>
        <p className="text-gray-600 mt-2 dark:text-gray-300">
          <strong className="text-black dark:text-white">Kategória: {gyogyszer.kategoria}</strong>
        </p>
        <p className="text-gray-500 italic text-sm dark:text-gray-400">
          <strong className="text-black dark:text-white">Megjegyzés: {gyogyszer.megjegyzes}</strong>
        </p>
      </div>
    ))}
  </div>
</div>

  );
}

