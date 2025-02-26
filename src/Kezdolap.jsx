import React from 'react';

export const Kezdőlap = () => {
  return (
    <div className="container text-center mt-5">
      <img src="beehealthyLogo.png" alt="BeeHealthy Logo" className="mb-4" style={{ width: "150px" }} />
      <h1 className="text-success fw-bold">Üdvözöljük a BeeHealthy weboldalon</h1>
      <p className="mt-3 lead text-gray-800 dark:text-gray-200">
        A BeeHealthy egy felhasználóbarát gyógyszerkezelő alkalmazás, amely segít
        a felhasználóknak nyomon követni és pontosan betartani a gyógyszeres
        terápiájukat.
      </p>
      <div className="card shadow-lg p-4 border-success mt-4">
        <p className="text-dark">
          Az alkalmazás emlékeztető funkcióval figyelmeztet a gyógyszerek bevételére,
          nyilvántartja az adagolást és az időpontokat, csökkentve a kihagyott adagok esélyét.
        </p>
        <p className="text-dark">
          Ezen felül lehetőséget biztosít a gyógyszerek leltározására, az orvosi előírások
          kezelésére, és figyelmeztet az esetleges gyógyszer-összeférhetetlenségekre is.
        </p>
        <p className="fw-bold text-success">
          Egyszerűsítsd és rendszerezd gyógyszerszedésed a BeeHealthy segítségével!
        </p>
      </div>
    </div>
  );
};