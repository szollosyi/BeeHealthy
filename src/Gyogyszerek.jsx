import React, { useState, useEffect } from 'react';
import axios from 'axios';

export const Gyogyszerek = () => {
  const [gyogyszerek, setGyogyszerek] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/beehealthy/')
      .then(response => setGyogyszerek(response.data))
      .catch(error => console.error('Hiba történt:', error));
  }, []);

  return (
    <div>
      <h1>Gyógyszerek listája</h1>
      <ul>
        {gyogyszerek.map(gyogyszer => (
          <li key={gyogyszer.id}>{gyogyszer.name}</li>
        ))}
      </ul>
    </div>
  );
};