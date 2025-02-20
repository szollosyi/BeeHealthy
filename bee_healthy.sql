-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Feb 20. 09:25
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.0.30

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
CREATE DATABASE IF NOT EXISTS `bee_healthy` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `bee_healthy`;

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
(1, 'Richter Gedeon Nyrt.', 'Budapest, Gyömrői út 19-21.', 'Magyarország legnagyobb gyógyszergyártó vállalata, nemzetközi piacvezető.'),
(2, 'Egis Gyógyszergyár Zrt.', 'Budapest, Keresztúri út 30-38.', 'Főként generikus készítményeket gyártó magyar vállalat.'),
(3, 'Sanofi Aventis Zrt.', 'Budapest, Tó utca 1-5.', 'Francia központú multinacionális gyógyszercég magyarországi leányvállalata.'),
(4, 'Teva Gyógyszergyár Zrt.', 'Debrecen, Pallagi út 13.', 'A világ egyik legnagyobb generikus gyógyszergyártója, jelentős magyarországi jelenléttel.'),
(5, 'Béres Gyógyszergyár Zrt.', 'Budapest, Mikoviny utca 2-4.', 'Vitaminokat és immunerősítő készítményeket gyártó magyar cég.'),
(6, 'Chinoin Zrt.', 'Budapest, Tó utca 1-5.', 'A Sanofi-csoporthoz tartozó magyar gyógyszeripari vállalat.'),
(7, 'Medi-Radiopharma Kft.', 'Érd, Diósdi út 24.', 'Sugárzó izotópokat és radiogyógyszereket fejlesztő magyar cég.'),
(8, 'Hungaropharma Zrt.', 'Budapest, Külső Váci út 80.', 'Gyógyszer-nagykereskedelemmel foglalkozó vállalat.'),
(9, 'Gedeon Pharma Kft.', 'Szeged, Kossuth Lajos sugárút 10.', 'Specializált gyógyszerészeti kutatócég.'),
(10, 'Pharmavit Zrt.', 'Budapest, Hűvösvölgyi út 64.', 'Étrend-kiegészítőket és vitaminokat gyártó magyar cég.'),
(11, 'HumanPharma Kft.', 'Debrecen, Egyetem tér 1.', 'Klinikai kutatásokat és gyógyszergyártást végző vállalat.'),
(12, 'Biogal Gyógyszergyár Zrt.', 'Debrecen, Szoboszlói út 50.', 'Állatgyógyászati készítményeket gyártó cég.'),
(13, 'Meditop Gyógyszeripari Kft.', 'Pilisborosjenő, Hunyadi utca 1.', 'Főként generikus gyógyszereket fejlesztő magyar vállalat.'),
(14, 'ExtractumPharma Zrt.', 'Hatvan, Rákóczi út 80.', 'Gyógynövény alapú készítmények és étrend-kiegészítők gyártója.'),
(15, 'Pharmagent Kft.', 'Sopron, Várkerület 5.', 'Gyógyszer-disztribúcióval foglalkozó magyar cég.'),
(16, 'Zentiva Magyarország Zrt.', 'Budapest, Csillaghegyi út 7.', 'A Zentiva csoport tagjaként generikus gyógyszereket fejleszt.'),
(17, 'Goodwill Pharma Kft.', 'Szeged, József Attila sugárút 87.', 'Étrend-kiegészítőket és orvostechnikai eszközöket forgalmaz.'),
(18, 'VitaPlus Kft.', 'Pécs, Ifjúság útja 23.', 'Vitaminokat és táplálékkiegészítőket fejlesztő magyar vállalat.'),
(19, 'Alkaloida Vegyészeti Gyár Zrt.', 'Tiszavasvári, Gyár utca 1.', 'Gyógyszerhatóanyagok és morfinszármazékok gyártásával foglalkozik.'),
(20, 'PannonPharma Kft.', 'Pécsvárad, Malom utca 2.', 'Kisméretű gyógyszergyártó üzem, innovatív készítmények fejlesztője.');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gyogyszer_adatok`
--

CREATE TABLE `gyogyszer_adatok` (
  `Id` int(11) NOT NULL,
  `Gyogyszer_nev` varchar(64) NOT NULL,
  `GyartoId` int(11) NOT NULL,
  `Kategoria` varchar(64) NOT NULL,
  `Megjegyzes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `gyogyszer_adatok`
--

INSERT INTO `gyogyszer_adatok` (`Id`, `Gyogyszer_nev`, `GyartoId`, `Kategoria`, `Megjegyzes`) VALUES
(1, 'Algopyrin', 1, 'Fájdalomcsillapító', 'Vény nélkül kapható'),
(2, 'No-Spa', 2, 'Görcsoldó', 'Belső görcsökre hatásos'),
(3, 'Aflamin', 3, 'Gyulladáscsökkentő', 'Ízületi fájdalmakra ajánlott'),
(4, 'Betadine', 4, 'Fertőtlenítő', 'Sebkezelésre ajánlott'),
(5, 'Aspirin Protect', 5, 'Vérhígító', 'Szívbetegeknek ajánlott'),
(6, 'Neo Citran', 6, 'Megfázás elleni', 'Influenza tüneteire'),
(7, 'Rubophen', 7, 'Lázcsillapító', 'Paracetamol tartalmú'),
(8, 'Frontin', 8, 'Nyugtató', 'Csak orvosi rendelvényre'),
(9, 'Tensiomin', 9, 'Vérnyomáscsökkentő', 'Magas vérnyomásra'),
(10, 'Panangin', 10, 'Szívgyógyszer', 'Kálium- és magnéziumpótlás'),
(11, 'CalciviD', 11, 'Csonterősítő', 'D-vitamint is tartalmaz'),
(12, 'Lopedium', 12, 'Hasmenés elleni', 'Akut hasmenés ellen'),
(13, 'Espumisan', 13, 'Puffadásgátló', 'Gázképződés csökkentésére'),
(14, 'Cataflam', 14, 'Gyulladáscsökkentő', 'Diklofenák tartalmú'),
(15, 'Xanax', 15, 'Nyugtató', 'Erős szorongásra ajánlott'),
(16, 'Tramadol', 16, 'Erős fájdalomcsillapító', 'Opiát tartalmú fájdalomcsillapító'),
(17, 'Magne B6', 17, 'Magnézium-kiegészítő', 'Izomgörcsökre, idegrendszeri támogatás'),
(18, 'D-vitamin', 18, 'Vitamin', 'Immunerősítésre ajánlott'),
(19, 'Supradyn', 19, 'Multivitamin', 'Vitamin- és ásványianyag pótlásra'),
(20, 'Cetirizin', 20, 'Antihisztamin', 'Allergiás tünetek enyhítésére'),
(21, 'Paracetamol', 1, 'Fájdalomcsillapító', 'Láz- és fájdalomcsillapító'),
(22, 'Ibuprofen', 2, 'Gyulladáscsökkentő', 'NSAID típusú gyulladáscsökkentő'),
(23, 'Metamizol', 3, 'Fájdalomcsillapító', 'Erősebb fájdalmakra ajánlott'),
(24, 'Nurofen', 4, 'Lázcsillapító', 'Gyermekeknek is ajánlott'),
(25, 'Rennie', 5, 'Savlekötő', 'Gyomorsav-problémákra'),
(26, 'Maalox', 6, 'Savlekötő', 'Reflux ellen'),
(27, 'Imodium', 7, 'Hasmenés elleni', 'Utazásokhoz ajánlott'),
(28, 'Drotaverin', 8, 'Görcsoldó', 'Hasi görcsök esetén'),
(29, 'Loratadin', 9, 'Antihisztamin', 'Allergiás tünetek ellen'),
(30, 'Fexofenadin', 10, 'Antihisztamin', 'Szezonális allergiákra'),
(31, 'Amoxicillin', 11, 'Antibiotikum', 'Bakteriális fertőzésekre'),
(32, 'Doxycyclin', 12, 'Antibiotikum', 'Légúti fertőzésekre'),
(33, 'Ciprofloxacin', 13, 'Antibiotikum', 'Erős bakteriális fertőzésekre'),
(34, 'Fluconazol', 14, 'Gombaellenes', 'Gombás fertőzések kezelésére'),
(35, 'Miconazole', 15, 'Gombaellenes', 'Helyi gombás fertőzésekre'),
(36, 'Omeprazol', 16, 'Gyomorsavcsökkentő', 'Gyomorégés és fekélyek ellen'),
(37, 'Pantoprazol', 17, 'Gyomorsavcsökkentő', 'Gastrooesophagealis reflux kezelésére'),
(38, 'Atorvastatin', 18, 'Koleszterincsökkentő', 'Magas koleszterinszint csökkentésére'),
(39, 'Rosuvastatin', 19, 'Koleszterincsökkentő', 'Érelmeszesedés ellen'),
(40, 'Lisinopril', 20, 'Vérnyomáscsökkentő', 'Magas vérnyomás kezelésére'),
(41, 'Perindopril', 1, 'Vérnyomáscsökkentő', 'ACE-gátló vérnyomáscsökkentő'),
(42, 'Bisoprolol', 2, 'Béta-blokkoló', 'Szívritmuszavarok és hipertónia ellen'),
(43, 'Metoprolol', 3, 'Béta-blokkoló', 'Szívproblémákra és stressz csökkentésére'),
(44, 'Verapamil', 4, 'Kalciumcsatorna-blokkoló', 'Magas vérnyomás kezelésére'),
(45, 'Amlodipin', 5, 'Kalciumcsatorna-blokkoló', 'Vérnyomáscsökkentő és érvédő'),
(46, 'Warfarin', 6, 'Véralvadásgátló', 'Vérrögképződés megelőzésére'),
(47, 'Dabigatran', 7, 'Véralvadásgátló', 'Stroke megelőzésére'),
(48, 'Rivaroxaban', 8, 'Véralvadásgátló', 'Mélyvénás trombózis ellen'),
(49, 'Enalapril', 9, 'Vérnyomáscsökkentő', 'ACE-gátló, vérnyomáscsökkentő'),
(50, 'Losartan', 10, 'Vérnyomáscsökkentő', 'Angiotenzin-receptor blokkoló'),
(51, 'Valsartan', 11, 'Vérnyomáscsökkentő', 'Magas vérnyomás és szívelégtelenség ellen'),
(52, 'Hydrochlorothiazid', 12, 'Vízhajtó', 'Vérnyomáscsökkentő vízhajtó'),
(53, 'Furosemid', 13, 'Vízhajtó', 'Erős vízhajtó'),
(54, 'Spironolacton', 14, 'Vízhajtó', 'Kálium-megtakarító vízhajtó'),
(55, 'Tamsulosin', 15, 'Prosztata gyógyszer', 'Prosztata megnagyobbodás ellen'),
(56, 'Finasteride', 16, 'Prosztata gyógyszer', 'Prosztata méretének csökkentése'),
(57, 'Duloxetin', 17, 'Antidepresszáns', 'Szorongás és depresszió kezelésére'),
(58, 'Sertralin', 18, 'Antidepresszáns', 'SSRI típusú antidepresszáns'),
(59, 'Citalopram', 19, 'Antidepresszáns', 'Hangulatzavarok kezelésére'),
(60, 'Alprazolam', 20, 'Szorongáscsökkentő', 'Benzodiazepin alapú nyugtató'),
(61, 'Diazepam', 1, 'Szorongáscsökkentő', 'Erősebb szorongás és görcsök ellen'),
(62, 'Clonazepam', 2, 'Epilepszia gyógyszer', 'Epilepsziás rohamok megelőzésére'),
(63, 'Carbamazepin', 3, 'Epilepszia gyógyszer', 'Epilepszia és neuralgia ellen'),
(64, 'Levetiracetam', 4, 'Epilepszia gyógyszer', 'Epilepszia elleni antikonvulzív szer'),
(65, 'Lamotrigin', 5, 'Epilepszia gyógyszer', 'Epilepsziára és bipoláris zavarokra'),
(66, 'Risperidon', 6, 'Antipszichotikum', 'Skizofrénia és bipoláris zavar ellen'),
(67, 'Olanzapin', 7, 'Antipszichotikum', 'Súlyos pszichiátriai betegségek kezelésére'),
(68, 'Aripiprazol', 8, 'Antipszichotikum', 'Skizofrénia és depresszió kezelése'),
(69, 'Quetiapin', 9, 'Antipszichotikum', 'Bipoláris zavar és pszichózis kezelése'),
(70, 'Levothyroxin', 10, 'Pajzsmirigy hormon', 'Pajzsmirigy-alulműködés kezelése'),
(71, 'Propylthiouracil', 11, 'Pajzsmirigy gyógyszer', 'Pajzsmirigy-túlműködés ellen'),
(72, 'Metformin', 12, 'Cukorbetegség gyógyszer', 'II-es típusú cukorbetegség kezelésére'),
(73, 'Gliclazid', 13, 'Cukorbetegség gyógyszer', 'Inzulinérzékenység növelése'),
(74, 'Insulin Glargin', 14, 'Cukorbetegség gyógyszer', 'Hosszú hatású inzulin'),
(75, 'Salbutamol', 15, 'Asztma gyógyszer', 'Légúti szűkületek oldása'),
(76, 'Budesonid', 16, 'Asztma gyógyszer', 'Gyulladáscsökkentő hatású inhalátor'),
(77, 'Montelukast', 17, 'Asztma gyógyszer', 'Hörgőgörcsök megelőzésére'),
(78, 'Theophyllin', 18, 'Asztma gyógyszer', 'Hörgőtágító hatású gyógyszer'),
(79, 'Tiotropium', 19, 'COPD gyógyszer', 'Hörgőtágító hatású inhalátor'),
(80, 'Ipratropium', 20, 'COPD gyógyszer', 'Légzéskönnyítő spray'),
(81, 'Omeprazol', 1, 'Gyomorvédő', 'Savcsökkentő gyomorfekély ellen'),
(82, 'Pantoprazol', 2, 'Gyomorvédő', 'GERD és gyomorfekély kezelésére'),
(83, 'Ranitidin', 3, 'Gyomorvédő', 'H2-receptor blokkoló'),
(84, 'Famotidin', 4, 'Gyomorvédő', 'Gyomorsavtermelés csökkentése'),
(85, 'Loperamid', 5, 'Hasmenés elleni gyógyszer', 'Hasmenés tüneteinek enyhítése'),
(86, 'Bisacodyl', 6, 'Székrekedés elleni gyógyszer', 'Hashajtó hatású gyógyszer'),
(87, 'Diosmin', 7, 'Visszér gyógyszer', 'Vénás keringés javítására'),
(88, 'Pentoxifyllin', 8, 'Érrendszeri gyógyszer', 'Perifériás érrendszeri problémákra'),
(89, 'Clopidogrel', 9, 'Vérhígító', 'Vérrögképződés megelőzésére'),
(90, 'Warfarin', 10, 'Vérhígító', 'Véralvadásgátló kezelés'),
(91, 'Dabigatran', 11, 'Vérhígító', 'Új generációs véralvadásgátló'),
(92, 'Atorvastatin', 12, 'Koleszterincsökkentő', 'Koleszterinszint csökkentése'),
(93, 'Rosuvastatin', 13, 'Koleszterincsökkentő', 'LDL koleszterin csökkentése'),
(94, 'Ezetimib', 14, 'Koleszterincsökkentő', 'Zsíranyagcsere szabályozása'),
(95, 'Digoxin', 15, 'Szívgyógyszer', 'Szívelégtelenség kezelésére'),
(96, 'Ivabradin', 16, 'Szívgyógyszer', 'Szívritmus csökkentése'),
(97, 'Amiodaron', 17, 'Szívritmuszavar elleni gyógyszer', 'Szívritmuszavar szabályozására'),
(98, 'Verapamil', 18, 'Szívritmuszavar elleni gyógyszer', 'Kalciumcsatorna-blokkoló'),
(99, 'Methotrexat', 19, 'Autoimmun gyógyszer', 'Autoimmun betegségek kezelésére'),
(100, 'Azathioprin', 20, 'Autoimmun gyógyszer', 'Immunszuppresszáns terápia');

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
(1, 'Dr. Kovács Péter', 'Belgyógyász'),
(2, 'Dr. Szabó Anna', 'Kardiológus'),
(3, 'Dr. Tóth Gábor', 'Sebész'),
(4, 'Dr. Nagy Éva', 'Neurológus'),
(5, 'Dr. Horváth László', 'Ortopéd szakorvos'),
(6, 'Dr. Varga Katalin', 'Endokrinológus'),
(7, 'Dr. Molnár Ferenc', 'Pulmonológus'),
(8, 'Dr. Kiss Judit', 'Reumatológus'),
(9, 'Dr. Farkas Zoltán', 'Urológus'),
(10, 'Dr. Balogh Márta', 'Nefrológus');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `paciensek`
--

CREATE TABLE `paciensek` (
  `id` int(11) NOT NULL,
  `nev` varchar(255) NOT NULL,
  `taj` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `paciensek`
--

INSERT INTO `paciensek` (`id`, `nev`, `taj`) VALUES
(1, 'Kiss Péter', '12345678901'),
(2, 'Nagy Anna', '23456789012'),
(3, 'Tóth Gábor', '34567890123'),
(4, 'Szabó Éva', '45678901234'),
(5, 'Horváth László', '56789012345'),
(6, 'Varga Katalin', '67890123456'),
(7, 'Molnár Ferenc', '78901234567'),
(8, 'Kovács Judit', '89012345678'),
(9, 'Farkas Zoltán', '90123456789'),
(10, 'Balogh Márta', '01234567890'),
(11, 'Takács Bence', '11223344556'),
(12, 'Szilágyi Noémi', '22334455667'),
(13, 'Papp Gergely', '33445566778'),
(14, 'Juhász Laura', '44556677889'),
(15, 'Simon Norbert', '55667788990'),
(16, 'Fekete Csilla', '66778899001'),
(17, 'Fehér Dániel', '77889900112'),
(18, 'Gál Tímea', '88990011223'),
(19, 'Bodnár Attila', '99001122334'),
(20, 'Lukács Szilvia', '10012233445'),
(21, 'Boros Tamás', '21123344556'),
(22, 'Sándor Mária', '32234455667'),
(23, 'Kelemen Zsolt', '43345566778'),
(24, 'Oláh Nikolett', '54456677889'),
(25, 'Fodor Balázs', '65567788990'),
(26, 'Hegedűs Lili', '76678899001'),
(27, 'Veres Ádám', '87789900112'),
(28, 'Deák Eszter', '98890011223'),
(29, 'Barta Krisztián', '09901122334'),
(30, 'Nemes Anett', '10912233445');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `receptek`
--

CREATE TABLE `receptek` (
  `Id` int(11) NOT NULL,
  `PaciensId` int(11) NOT NULL,
  `GyogyszerId` int(11) NOT NULL,
  `OrvosId` int(11) NOT NULL,
  `Kezelesi_idopont` varchar(64) NOT NULL,
  `Kezeles_kezdete` date NOT NULL,
  `Kezeles_vege` date NOT NULL,
  `Adagolas` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `receptek`
--

INSERT INTO `receptek` (`Id`, `PaciensId`, `GyogyszerId`, `OrvosId`, `Kezelesi_idopont`, `Kezeles_kezdete`, `Kezeles_vege`, `Adagolas`) VALUES
(1, 1, 5, 3, '08:00', '2024-05-01', '2024-05-30', 'Napi 1 tabletta'),
(2, 2, 12, 1, '09:30', '2024-05-02', '2024-06-01', 'Napi 2 kapszula'),
(3, 3, 8, 4, '10:15', '2024-05-03', '2024-06-02', 'Reggel és este 1 tabletta'),
(4, 4, 15, 2, '11:45', '2024-05-04', '2024-06-03', 'Hetente 3 injekció'),
(5, 5, 22, 6, '14:00', '2024-05-05', '2024-06-04', 'Naponta 5 ml szirup'),
(6, 6, 30, 5, '15:30', '2024-05-06', '2024-06-05', '2 tabletta reggel'),
(7, 7, 18, 8, '16:45', '2024-05-07', '2024-06-06', 'Napi 3×1 tabletta'),
(8, 8, 25, 7, '18:00', '2024-05-08', '2024-06-07', 'Hetente 1 tapasz'),
(9, 9, 3, 9, '19:15', '2024-05-09', '2024-06-08', 'Szükség esetén 1 kapszula'),
(10, 10, 10, 10, '20:30', '2024-05-10', '2024-06-09', 'Reggel éhgyomorra 1 tabletta');

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
(16, 'admin', '02853337260d08f15eeb704bea2b1e06affc6c3856dfd73f319ae5085fa29cfd', 'F6k6XzkIoZJIhoTsdnYzt3aKtGfpoyxBpEWgL1BofLOt6sQjWJbbODHV9fxA8j8F', 'Admin Admin', 9, 1, 'admin@admin.com', 'C:\\Users\\Vizsga\\Desktop\\hátterek\\Screenshot_20241126_104834_TikT'),
(17, 'TBalazs', '58142a6b7cd5f2bdbc7c9867cab5810243ae93c555194a78fbe1a6963183f5a3', 'x0R5y8uKnR9E2YDPPUhSaj5dLUtAeeB9FZni82b2uX0QKlSJ49d12iPqfwfImFuF', 'Tisza Balázs', 9, 1, 'tiszab@kkszki.hu', 'C:\\Users\\Vizsga\\Desktop\\hátterek\\The Rock anão.jpg'),
(18, 'SzIstvan', '0baf1a88448a80f8c107196ca7998a1649f6adb5a0c75051b3597de915e4e955', 'X1j2n3xPcuAWJKG9V2TLHmSF0AWQHgtNUWwoaqRpPrsuUTFwPOXLOrbdJ92aipZ7', 'Szőllősy István', 9, 1, 'szollosyi@kkszki.hu', 'C:\\Users\\Vizsga\\Desktop\\hátterek\\images (1).jpg'),
(19, 'DZoltan', 'bf63e716be989bc375936e6b1831a288ddf94bc75512533175562f48381109f5', '289cJSpLZ59sE1U3C5fm0pPO4tLT1pF6gjm6f0LGIssCeGYE3sDGGDf7ZFeGQmWi', 'Dombai Zoltán', 9, 1, 'dombaiz@kkszki.hu', 'C:\\Users\\Vizsga\\Desktop\\hátterek\\plants vs zombies.jpg');

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
-- A tábla indexei `paciensek`
--
ALTER TABLE `paciensek`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `taj` (`taj`);

--
-- A tábla indexei `receptek`
--
ALTER TABLE `receptek`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `GyogyszerId` (`GyogyszerId`),
  ADD KEY `OrvosId` (`OrvosId`),
  ADD KEY `PaciensId` (`PaciensId`);

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `gyogyszer_adatok`
--
ALTER TABLE `gyogyszer_adatok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT a táblához `orvosok`
--
ALTER TABLE `orvosok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `paciensek`
--
ALTER TABLE `paciensek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT a táblához `receptek`
--
ALTER TABLE `receptek`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

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
  ADD CONSTRAINT `receptek_ibfk_2` FOREIGN KEY (`GyogyszerId`) REFERENCES `gyogyszer_adatok` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receptek_ibfk_3` FOREIGN KEY (`OrvosId`) REFERENCES `orvosok` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receptek_ibfk_4` FOREIGN KEY (`PaciensId`) REFERENCES `paciensek` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
