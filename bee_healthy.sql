-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Feb 12. 07:38
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `bee_healthy`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gyarto`
--

CREATE TABLE `gyarto` (
  `Id` int(11) NOT NULL,
  `Nev` varchar(64) NOT NULL,
  `Cim` varchar(64) NOT NULL,
  `Leiras` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `gyarto`
--

INSERT INTO `gyarto` (`Id`, `Nev`, `Cim`, `Leiras`) VALUES
(1, 'Pfhizer', 'USA', 'Szuri'),
(2, 'SANOFI', 'EU', 'Tabletták'),
(3, 'próbagyartonév', 'próbagyartocím', 'próbagyartoleiras');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gyogyszer_adatok`
--

CREATE TABLE `gyogyszer_adatok` (
  `Id` int(11) NOT NULL,
  `Gyogyszer_nev` varchar(64) NOT NULL,
  `GyartoId` int(11) NOT NULL,
  `Kategoria` varchar(64) NOT NULL,
  `Adagolas` varchar(64) NOT NULL,
  `Kezelesi_idopont` varchar(64) NOT NULL,
  `Kezeles_idotartama` varchar(64) NOT NULL,
  `Emlekezteto` date NOT NULL,
  `Megjegyzes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `gyogyszer_adatok`
--

INSERT INTO `gyogyszer_adatok` (`Id`, `Gyogyszer_nev`, `GyartoId`, `Kategoria`, `Adagolas`, `Kezelesi_idopont`, `Kezeles_idotartama`, `Emlekezteto`, `Megjegyzes`) VALUES
(1, 'Algopyrin', 1, 'Láz - és fájdalomcsillapító', 'Napi max 2 ', 'Délben és este 7 órakor', 'Egy héten át', '2024-12-15', 'Ha a fájdalom nem múlik , az adagolás száma növelhető max 1 darabszámal'),
(2, 'Covid oltás', 1, 'Injekció', '1 db', 'Emailben kapott időpontban', '10 perc', '2025-02-13', 'Maszkban jelenjen meg'),
(3, 'string', 3, 'string', 'string', 'string', 'string', '2025-02-11', 'string'),
(4, 'string', 1, 'string', 'string', 'string', 'string', '2025-02-11', 'string');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orvosok`
--

CREATE TABLE `orvosok` (
  `Id` int(11) NOT NULL,
  `Nev` varchar(64) NOT NULL,
  `Beosztas` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `orvosok`
--

INSERT INTO `orvosok` (`Id`, `Nev`, `Beosztas`) VALUES
(1, 'Dr House', 'Vezér orvos'),
(2, 'Richter Gedeon', 'Csontkovács');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `receptek`
--

CREATE TABLE `receptek` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `GyogyszerId` int(11) NOT NULL,
  `OrvosId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `receptek`
--

INSERT INTO `receptek` (`Id`, `UserId`, `GyogyszerId`, `OrvosId`) VALUES
(1, 1, 2, 1),
(2, 15, 2, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `Id` int(11) NOT NULL,
  `LoginNev` varchar(16) NOT NULL,
  `HASH` varchar(64) NOT NULL,
  `SALT` varchar(64) NOT NULL,
  `Name` varchar(64) NOT NULL,
  `PermissionId` int(11) NOT NULL,
  `Active` tinyint(1) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `ProfilePicturePath` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`Id`, `LoginNev`, `HASH`, `SALT`, `Name`, `PermissionId`, `Active`, `Email`, `ProfilePicturePath`) VALUES
(1, 'kerenyir', 'd5fe0e517520122f1ab363b6b7ee9ae616e7ad393693ef00d81a7f287a79931a', 'Gm63C4jiWnYvfZfiKUu2cu8AHPNDj8NoHhtQn88yiJhyOunBNSd7tRoWo5wwqg9X', 'Kerényi Róbert', 9, 1, 'kerenyir@kkszki.hu', 'default.jpg'),
(11, 'string', '473287f8298dba7163a897908958f7c0eae733e25d2e027992ea2edc9bed2fa8', 'string', 'string', 1, 0, 'zimaz@kkszki.hu', 'string'),
(14, 'string3', '2984285', '9526984', 'string', 0, 1, 'string3', 'string'),
(15, 'UjEmber', '1042b9e964b97f96099bcafd747e56ca04169f5e81a5374dab227362e95832f5', 'kY4Lma0h1ZNM5iz1SvD1chpkOECkHG8inGYcPHQYi51vnNu02ctEPZeUfz2QkKyU', 'Új ember', 9, 1, 'ftvzgbuhnijmko', 'Nincs kiválasztva');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `gyarto`
--
ALTER TABLE `gyarto`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `gyogyszer_adatok`
--
ALTER TABLE `gyogyszer_adatok`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `GyartoId` (`GyartoId`);

--
-- A tábla indexei `orvosok`
--
ALTER TABLE `orvosok`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `receptek`
--
ALTER TABLE `receptek`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UserId` (`UserId`),
  ADD KEY `GyogyszerId` (`GyogyszerId`),
  ADD KEY `OrvosId` (`OrvosId`);

--
-- A tábla indexei `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `LoginNev` (`LoginNev`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `Jog` (`PermissionId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `gyarto`
--
ALTER TABLE `gyarto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `gyogyszer_adatok`
--
ALTER TABLE `gyogyszer_adatok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT a táblához `orvosok`
--
ALTER TABLE `orvosok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `receptek`
--
ALTER TABLE `receptek`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `gyogyszer_adatok`
--
ALTER TABLE `gyogyszer_adatok`
  ADD CONSTRAINT `gyogyszer_adatok_ibfk_1` FOREIGN KEY (`GyartoId`) REFERENCES `gyarto` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `receptek`
--
ALTER TABLE `receptek`
  ADD CONSTRAINT `receptek_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receptek_ibfk_2` FOREIGN KEY (`GyogyszerId`) REFERENCES `gyogyszer_adatok` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receptek_ibfk_3` FOREIGN KEY (`OrvosId`) REFERENCES `orvosok` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
