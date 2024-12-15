-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 15, 2024 at 03:05 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bee_healthy`
--

-- --------------------------------------------------------

--
-- Table structure for table `felhasznaloi_adatok`
--

CREATE TABLE `felhasznaloi_adatok` (
  `Id` int(11) NOT NULL,
  `Nev` varchar(64) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `Jelszo` varchar(20) NOT NULL,
  `Szuletesi_datum` varchar(11) NOT NULL,
  `Kapcsolat` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `felhasznaloi_adatok`
--

INSERT INTO `felhasznaloi_adatok` (`Id`, `Nev`, `Email`, `Jelszo`, `Szuletesi_datum`, `Kapcsolat`) VALUES
(1, 'Tihanyi  Tihamér', 'ttihamer@gmail.com', 'tihanyiak', '1990.09.09', 'Tihany\r\nTelefonszám : +36301234567');

-- --------------------------------------------------------

--
-- Table structure for table `gyogyszer_adatok`
--

CREATE TABLE `gyogyszer_adatok` (
  `Id` int(11) NOT NULL,
  `Gyogyszer_nev` varchar(64) NOT NULL,
  `Marka` varchar(64) NOT NULL,
  `Kategoria` varchar(64) NOT NULL,
  `Adagolas` varchar(64) NOT NULL,
  `Kezelesi_idopont` varchar(64) NOT NULL,
  `Kezeles_idotartama` varchar(64) NOT NULL,
  `Emlekezteto` date NOT NULL,
  `Megjegyzes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `gyogyszer_adatok`
--

INSERT INTO `gyogyszer_adatok` (`Id`, `Gyogyszer_nev`, `Marka`, `Kategoria`, `Adagolas`, `Kezelesi_idopont`, `Kezeles_idotartama`, `Emlekezteto`, `Megjegyzes`) VALUES
(1, 'Algopyrin', 'SANOFI', 'Láz - és fájdalomcsillapító', 'Napi max 2 ', 'Délben és este 7 órakor', 'Egy héten át', '2024-12-15', 'Ha a fájdalom nem múlik , az adagolás száma növelhető max 1 darabszámal');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `felhasznaloi_adatok`
--
ALTER TABLE `felhasznaloi_adatok`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `gyogyszer_adatok`
--
ALTER TABLE `gyogyszer_adatok`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `felhasznaloi_adatok`
--
ALTER TABLE `felhasznaloi_adatok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `gyogyszer_adatok`
--
ALTER TABLE `gyogyszer_adatok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
