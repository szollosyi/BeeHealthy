-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Feb 19. 09:10
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
  `Adagolas` varchar(64) NOT NULL,
  `Kezelesi_idopont` varchar(64) NOT NULL,
  `KezelesKezdete` date NOT NULL,
  `KezelesVege` date NOT NULL,
  `Emlekezteto` date NOT NULL,
  `Megjegyzes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `gyogyszer_adatok`
--

INSERT INTO `gyogyszer_adatok` (`Id`, `Gyogyszer_nev`, `GyartoId`, `Kategoria`, `Adagolas`, `Kezelesi_idopont`, `KezelesKezdete`, `KezelesVege`, `Emlekezteto`, `Megjegyzes`) VALUES
(1, 'Algopyrin', 1, 'Fájdalomcsillapító', '1 tabletta 8 óránként', '08:00', '2024-02-01', '2024-03-01', '2024-02-15', 'Vény nélkül kapható'),
(2, 'No-Spa', 2, 'Görcsoldó', '1-2 tabletta szükség szerint', '12:00', '2024-02-05', '2024-03-05', '2024-02-20', 'Belső görcsökre hatásos'),
(3, 'Aflamin', 3, 'Gyulladáscsökkentő', '2 tabletta naponta', '09:00', '2024-02-10', '2024-03-10', '2024-02-25', 'Ízületi fájdalmakra ajánlott'),
(4, 'Betadine', 4, 'Fertőtlenítő', 'Külsőleg, napi 2x', '07:00', '2024-02-12', '2024-03-12', '2024-02-27', 'Sebkezelésre ajánlott'),
(5, 'Aspirin Protect', 5, 'Vérhígító', '1 tabletta naponta', '08:30', '2024-02-15', '2024-03-15', '2024-03-01', 'Szívbetegeknek ajánlott'),
(6, 'Neo Citran', 6, 'Megfázás elleni', '1 tasak 6 óránként', '20:00', '2024-02-18', '2024-03-18', '2024-03-03', 'Influenza tüneteire'),
(7, 'Rubophen', 7, 'Lázcsillapító', '2 tabletta szükség szerint', '10:00', '2024-02-20', '2024-03-20', '2024-03-05', 'Paracetamol tartalmú'),
(8, 'Frontin', 8, 'Nyugtató', '1 tabletta este', '22:00', '2024-02-22', '2024-03-22', '2024-03-07', 'Csak orvosi rendelvényre'),
(9, 'Tensiomin', 9, 'Vérnyomáscsökkentő', '1 tabletta reggel', '08:00', '2024-02-25', '2024-03-25', '2024-03-10', 'Magas vérnyomásra'),
(10, 'Panangin', 10, 'Szívgyógyszer', '2 tabletta naponta', '11:00', '2024-02-27', '2024-03-27', '2024-03-12', 'Kálium- és magnéziumpótlás'),
(11, 'CalciviD', 11, 'Csonterősítő', '1 tabletta naponta', '09:30', '2024-02-28', '2024-03-28', '2024-03-13', 'D-vitamint is tartalmaz'),
(12, 'Lopedium', 12, 'Hasmenés elleni', '1 kapszula szükség szerint', '13:00', '2024-03-01', '2024-03-31', '2024-03-15', 'Akut hasmenés ellen'),
(13, 'Espumisan', 13, 'Puffadásgátló', '2 kapszula étkezés után', '14:00', '2024-03-02', '2024-04-01', '2024-03-17', 'Gázképződés csökkentésére'),
(14, 'Cataflam', 14, 'Gyulladáscsökkentő', '1 tabletta 12 óránként', '15:00', '2024-03-05', '2024-04-05', '2024-03-20', 'Diklofenák tartalmú'),
(15, 'Xanax', 15, 'Nyugtató', '1 tabletta este', '22:30', '2024-03-07', '2024-04-07', '2024-03-22', 'Erős szorongásra ajánlott'),
(16, 'Tramadol', 16, 'Erős fájdalomcsillapító', '1 kapszula 8 óránként', '06:00', '2024-03-10', '2024-04-10', '2024-03-25', 'Opiát tartalmú fájdalomcsillapító'),
(17, 'Magne B6', 17, 'Magnézium-kiegészítő', '2 tabletta naponta', '12:30', '2024-03-12', '2024-04-12', '2024-03-27', 'Izomgörcsökre, idegrendszeri támogatás'),
(18, 'D-vitamin', 18, 'Vitamin', '1 csepp naponta', '08:45', '2024-03-15', '2024-04-15', '2024-03-30', 'Immunerősítésre ajánlott'),
(19, 'Supradyn', 19, 'Multivitamin', '1 tabletta reggel', '07:30', '2024-03-18', '2024-04-18', '2024-04-02', 'Vitamin- és ásványianyag pótlásra'),
(20, 'Cetirizin', 20, 'Antihisztamin', '1 tabletta este', '21:00', '2024-03-20', '2024-04-20', '2024-04-05', 'Allergiás tünetek enyhítésére'),
(21, 'Paracetamol', 1, 'Fájdalomcsillapító', '1 tabletta 6 óránként', '08:00', '2024-03-22', '2024-04-22', '2024-04-07', 'Láz- és fájdalomcsillapító'),
(22, 'Ibuprofen', 2, 'Gyulladáscsökkentő', '1 tabletta 8 óránként', '10:00', '2024-03-24', '2024-04-24', '2024-04-09', 'NSAID típusú gyulladáscsökkentő'),
(23, 'Metamizol', 3, 'Fájdalomcsillapító', '1 tabletta 12 óránként', '12:00', '2024-03-25', '2024-04-25', '2024-04-10', 'Erősebb fájdalmakra ajánlott'),
(24, 'Nurofen', 4, 'Lázcsillapító', '1 tabletta 8 óránként', '14:00', '2024-03-26', '2024-04-26', '2024-04-11', 'Gyermekeknek is ajánlott'),
(25, 'Rennie', 5, 'Savlekötő', '1 tabletta szükség szerint', '16:00', '2024-03-27', '2024-04-27', '2024-04-12', 'Gyomorsav-problémákra'),
(26, 'Maalox', 6, 'Savlekötő', '1 tasak szükség szerint', '18:00', '2024-03-28', '2024-04-28', '2024-04-13', 'Reflux ellen'),
(27, 'Imodium', 7, 'Hasmenés elleni', '1 kapszula szükség szerint', '20:00', '2024-03-29', '2024-04-29', '2024-04-14', 'Utazásokhoz ajánlott'),
(28, 'Drotaverin', 8, 'Görcsoldó', '1 tabletta szükség szerint', '22:00', '2024-03-30', '2024-04-30', '2024-04-15', 'Hasi görcsök esetén'),
(29, 'Loratadin', 9, 'Antihisztamin', '1 tabletta reggel', '07:30', '2024-04-01', '2024-05-01', '2024-04-16', 'Allergiás tünetek ellen'),
(30, 'Fexofenadin', 10, 'Antihisztamin', '1 tabletta este', '21:30', '2024-04-02', '2024-05-02', '2024-04-17', 'Szezonális allergiákra'),
(31, 'Amoxicillin', 11, 'Antibiotikum', '1 kapszula 8 óránként', '09:00', '2024-04-03', '2024-05-03', '2024-04-18', 'Bakteriális fertőzésekre'),
(32, 'Doxycyclin', 12, 'Antibiotikum', '1 kapszula reggel és este', '08:00', '2024-04-04', '2024-05-04', '2024-04-19', 'Légúti fertőzésekre'),
(33, 'Ciprofloxacin', 13, 'Antibiotikum', '1 tabletta 12 óránként', '10:30', '2024-04-05', '2024-05-05', '2024-04-20', 'Erős bakteriális fertőzésekre'),
(34, 'Fluconazol', 14, 'Gombaellenes', '1 tabletta hetente', '11:00', '2024-04-06', '2024-05-06', '2024-04-21', 'Gombás fertőzések kezelésére'),
(35, 'Miconazole', 15, 'Gombaellenes', '1 krém napi kétszer', '17:00', '2024-04-07', '2024-05-07', '2024-04-22', 'Helyi gombás fertőzésekre'),
(36, 'Omeprazol', 16, 'Gyomorsavcsökkentő', '1 kapszula reggel', '08:30', '2024-04-08', '2024-05-08', '2024-04-23', 'Gyomorégés és fekélyek ellen'),
(37, 'Pantoprazol', 17, 'Gyomorsavcsökkentő', '1 tabletta reggel', '07:00', '2024-04-09', '2024-05-09', '2024-04-24', 'Gastrooesophagealis reflux kezelésére'),
(38, 'Atorvastatin', 18, 'Koleszterincsökkentő', '1 tabletta este', '22:00', '2024-04-10', '2024-05-10', '2024-04-25', 'Magas koleszterinszint csökkentésére'),
(39, 'Rosuvastatin', 19, 'Koleszterincsökkentő', '1 tabletta reggel', '08:00', '2024-04-11', '2024-05-11', '2024-04-26', 'Érelmeszesedés ellen'),
(40, 'Lisinopril', 20, 'Vérnyomáscsökkentő', '1 tabletta naponta', '09:00', '2024-04-12', '2024-05-12', '2024-04-27', 'Magas vérnyomás kezelésére'),
(41, 'Perindopril', 1, 'Vérnyomáscsökkentő', '1 tabletta reggel', '07:30', '2024-04-13', '2024-05-13', '2024-04-28', 'ACE-gátló vérnyomáscsökkentő'),
(42, 'Bisoprolol', 2, 'Béta-blokkoló', '1 tabletta reggel', '07:00', '2024-04-14', '2024-05-14', '2024-04-29', 'Szívritmuszavarok és hipertónia ellen'),
(43, 'Metoprolol', 3, 'Béta-blokkoló', '1 tabletta naponta', '08:00', '2024-04-15', '2024-05-15', '2024-04-30', 'Szívproblémákra és stressz csökkentésére'),
(44, 'Verapamil', 4, 'Kalciumcsatorna-blokkoló', '1 tabletta 12 óránként', '10:00', '2024-04-16', '2024-05-16', '2024-05-01', 'Magas vérnyomás kezelésére'),
(45, 'Amlodipin', 5, 'Kalciumcsatorna-blokkoló', '1 tabletta este', '21:00', '2024-04-17', '2024-05-17', '2024-05-02', 'Vérnyomáscsökkentő és érvédő'),
(46, 'Warfarin', 6, 'Véralvadásgátló', '1 tabletta naponta', '19:00', '2024-04-18', '2024-05-18', '2024-05-03', 'Vérrögképződés megelőzésére'),
(47, 'Dabigatran', 7, 'Véralvadásgátló', '1 kapszula naponta', '18:00', '2024-04-19', '2024-05-19', '2024-05-04', 'Stroke megelőzésére'),
(48, 'Rivaroxaban', 8, 'Véralvadásgátló', '1 tabletta este', '20:00', '2024-04-20', '2024-05-20', '2024-05-05', 'Mélyvénás trombózis ellen'),
(49, 'Enalapril', 9, 'Vérnyomáscsökkentő', '1 tabletta reggel', '07:00', '2024-04-21', '2024-05-21', '2024-05-06', 'ACE-gátló, vérnyomáscsökkentő'),
(50, 'Losartan', 10, 'Vérnyomáscsökkentő', '1 tabletta este', '20:00', '2024-04-22', '2024-05-22', '2024-05-07', 'Angiotenzin-receptor blokkoló'),
(51, 'Valsartan', 11, 'Vérnyomáscsökkentő', '1 tabletta naponta', '09:00', '2024-04-23', '2024-05-23', '2024-05-08', 'Magas vérnyomás és szívelégtelenség ellen'),
(52, 'Hydrochlorothiazid', 12, 'Vízhajtó', '1 tabletta reggel', '08:00', '2024-04-24', '2024-05-24', '2024-05-09', 'Vérnyomáscsökkentő vízhajtó'),
(53, 'Furosemid', 13, 'Vízhajtó', '1 tabletta reggel', '07:30', '2024-04-25', '2024-05-25', '2024-05-10', 'Erős vízhajtó'),
(54, 'Spironolacton', 14, 'Vízhajtó', '1 tabletta naponta', '10:00', '2024-04-26', '2024-05-26', '2024-05-11', 'Kálium-megtakarító vízhajtó'),
(55, 'Tamsulosin', 15, 'Prosztata gyógyszer', '1 kapszula reggel', '09:30', '2024-04-27', '2024-05-27', '2024-05-12', 'Prosztata megnagyobbodás ellen'),
(56, 'Finasteride', 16, 'Prosztata gyógyszer', '1 tabletta naponta', '08:30', '2024-04-28', '2024-05-28', '2024-05-13', 'Prosztata méretének csökkentése'),
(57, 'Duloxetin', 17, 'Antidepresszáns', '1 kapszula reggel', '07:45', '2024-04-29', '2024-05-29', '2024-05-14', 'Szorongás és depresszió kezelésére'),
(58, 'Sertralin', 18, 'Antidepresszáns', '1 tabletta reggel', '07:15', '2024-04-30', '2024-05-30', '2024-05-15', 'SSRI típusú antidepresszáns'),
(59, 'Citalopram', 19, 'Antidepresszáns', '1 tabletta naponta', '09:00', '2024-05-01', '2024-05-31', '2024-05-16', 'Hangulatzavarok kezelésére'),
(60, 'Alprazolam', 20, 'Szorongáscsökkentő', '1 tabletta este', '21:00', '2024-05-02', '2024-06-01', '2024-05-17', 'Benzodiazepin alapú nyugtató'),
(61, 'Diazepam', 1, 'Szorongáscsökkentő', '1 tabletta szükség szerint', '22:00', '2024-05-03', '2024-06-02', '2024-05-18', 'Erősebb szorongás és görcsök ellen'),
(62, 'Clonazepam', 2, 'Epilepszia gyógyszer', '1 tabletta naponta', '20:30', '2024-05-04', '2024-06-03', '2024-05-19', 'Epilepsziás rohamok megelőzésére'),
(63, 'Carbamazepin', 3, 'Epilepszia gyógyszer', '1 tabletta reggel és este', '07:00', '2024-05-05', '2024-06-04', '2024-05-20', 'Epilepszia és neuralgia ellen'),
(64, 'Levetiracetam', 4, 'Epilepszia gyógyszer', '1 tabletta naponta', '08:30', '2024-05-06', '2024-06-05', '2024-05-21', 'Epilepszia elleni antikonvulzív szer'),
(65, 'Lamotrigin', 5, 'Epilepszia gyógyszer', '1 tabletta este', '19:30', '2024-05-07', '2024-06-06', '2024-05-22', 'Epilepsziára és bipoláris zavarokra'),
(66, 'Risperidon', 6, 'Antipszichotikum', '1 tabletta este', '21:00', '2024-05-08', '2024-06-07', '2024-05-23', 'Skizofrénia és bipoláris zavar ellen'),
(67, 'Olanzapin', 7, 'Antipszichotikum', '1 tabletta este', '22:30', '2024-05-09', '2024-06-08', '2024-05-24', 'Súlyos pszichiátriai betegségek kezelésére'),
(68, 'Aripiprazol', 8, 'Antipszichotikum', '1 tabletta naponta', '10:00', '2024-05-10', '2024-06-09', '2024-05-25', 'Skizofrénia és depresszió kezelése'),
(69, 'Quetiapin', 9, 'Antipszichotikum', '1 tabletta este', '20:00', '2024-05-11', '2024-06-10', '2024-05-26', 'Bipoláris zavar és pszichózis kezelése'),
(70, 'Levothyroxin', 10, 'Pajzsmirigy hormon', '1 tabletta reggel éhgyomorra', '06:30', '2024-05-12', '2024-06-11', '2024-05-27', 'Pajzsmirigy-alulműködés kezelése'),
(71, 'Propylthiouracil', 11, 'Pajzsmirigy gyógyszer', '1 tabletta naponta', '07:00', '2024-05-13', '2024-06-12', '2024-05-28', 'Pajzsmirigy-túlműködés ellen'),
(72, 'Metformin', 12, 'Cukorbetegség gyógyszer', '1 tabletta reggel és este', '08:00', '2024-05-14', '2024-06-13', '2024-05-29', 'II-es típusú cukorbetegség kezelésére'),
(73, 'Gliclazid', 13, 'Cukorbetegség gyógyszer', '1 tabletta reggel', '07:30', '2024-05-15', '2024-06-14', '2024-05-30', 'Inzulinérzékenység növelése'),
(74, 'Insulin Glargin', 14, 'Cukorbetegség gyógyszer', '1 injekció este', '22:00', '2024-05-16', '2024-06-15', '2024-05-31', 'Hosszú hatású inzulin'),
(75, 'Salbutamol', 15, 'Asztma gyógyszer', '1 inhaláció szükség szerint', '18:00', '2024-05-17', '2024-06-16', '2024-06-01', 'Légúti szűkületek oldása'),
(76, 'Budesonid', 16, 'Asztma gyógyszer', '1 inhaláció naponta', '19:00', '2024-05-18', '2024-06-17', '2024-06-02', 'Gyulladáscsökkentő hatású inhalátor'),
(77, 'Montelukast', 17, 'Asztma gyógyszer', '1 tabletta este', '21:30', '2024-05-19', '2024-06-18', '2024-06-03', 'Hörgőgörcsök megelőzésére'),
(78, 'Theophyllin', 18, 'Asztma gyógyszer', '1 tabletta reggel', '08:00', '2024-05-20', '2024-06-19', '2024-06-04', 'Hörgőtágító hatású gyógyszer'),
(79, 'Tiotropium', 19, 'COPD gyógyszer', '1 inhaláció naponta', '10:00', '2024-05-21', '2024-06-20', '2024-06-05', 'Hörgőtágító hatású inhalátor'),
(80, 'Ipratropium', 20, 'COPD gyógyszer', '1 inhaláció szükség szerint', '11:00', '2024-05-22', '2024-06-21', '2024-06-06', 'Légzéskönnyítő spray'),
(81, 'Omeprazol', 1, 'Gyomorvédő', '1 kapszula reggel éhgyomorra', '07:30', '2024-05-23', '2024-06-22', '2024-06-07', 'Savcsökkentő gyomorfekély ellen'),
(82, 'Pantoprazol', 2, 'Gyomorvédő', '1 kapszula naponta', '08:00', '2024-05-24', '2024-06-23', '2024-06-08', 'GERD és gyomorfekély kezelésére'),
(83, 'Ranitidin', 3, 'Gyomorvédő', '1 tabletta este', '21:00', '2024-05-25', '2024-06-24', '2024-06-09', 'H2-receptor blokkoló'),
(84, 'Famotidin', 4, 'Gyomorvédő', '1 tabletta reggel', '09:00', '2024-05-26', '2024-06-25', '2024-06-10', 'Gyomorsavtermelés csökkentése'),
(85, 'Loperamid', 5, 'Hasmenés elleni gyógyszer', '1 kapszula szükség szerint', '12:00', '2024-05-27', '2024-06-26', '2024-06-11', 'Hasmenés tüneteinek enyhítése'),
(86, 'Bisacodyl', 6, 'Székrekedés elleni gyógyszer', '1 tabletta este', '22:00', '2024-05-28', '2024-06-27', '2024-06-12', 'Hashajtó hatású gyógyszer'),
(87, 'Diosmin', 7, 'Visszér gyógyszer', '1 tabletta reggel', '08:30', '2024-05-29', '2024-06-28', '2024-06-13', 'Vénás keringés javítására'),
(88, 'Pentoxifyllin', 8, 'Érrendszeri gyógyszer', '1 tabletta naponta', '10:30', '2024-05-30', '2024-06-29', '2024-06-14', 'Perifériás érrendszeri problémákra'),
(89, 'Clopidogrel', 9, 'Vérhígító', '1 tabletta reggel', '09:00', '2024-05-31', '2024-06-30', '2024-06-15', 'Vérrögképződés megelőzésére'),
(90, 'Warfarin', 10, 'Vérhígító', '1 tabletta este', '19:30', '2024-06-01', '2024-07-01', '2024-06-16', 'Véralvadásgátló kezelés'),
(91, 'Dabigatran', 11, 'Vérhígító', '1 kapszula naponta', '18:00', '2024-06-02', '2024-07-02', '2024-06-17', 'Új generációs véralvadásgátló'),
(92, 'Atorvastatin', 12, 'Koleszterincsökkentő', '1 tabletta este', '21:00', '2024-06-03', '2024-07-03', '2024-06-18', 'Koleszterinszint csökkentése'),
(93, 'Rosuvastatin', 13, 'Koleszterincsökkentő', '1 tabletta naponta', '20:00', '2024-06-04', '2024-07-04', '2024-06-19', 'LDL koleszterin csökkentése'),
(94, 'Ezetimib', 14, 'Koleszterincsökkentő', '1 tabletta reggel', '07:00', '2024-06-05', '2024-07-05', '2024-06-20', 'Zsíranyagcsere szabályozása'),
(95, 'Digoxin', 15, 'Szívgyógyszer', '1 tabletta naponta', '08:30', '2024-06-06', '2024-07-06', '2024-06-21', 'Szívelégtelenség kezelésére'),
(96, 'Ivabradin', 16, 'Szívgyógyszer', '1 tabletta reggel és este', '07:30', '2024-06-07', '2024-07-07', '2024-06-22', 'Szívritmus csökkentése'),
(97, 'Amiodaron', 17, 'Szívritmuszavar elleni gyógyszer', '1 tabletta naponta', '09:00', '2024-06-08', '2024-07-08', '2024-06-23', 'Szívritmuszavar szabályozására'),
(98, 'Verapamil', 18, 'Szívritmuszavar elleni gyógyszer', '1 tabletta naponta', '10:00', '2024-06-09', '2024-07-09', '2024-06-24', 'Kalciumcsatorna-blokkoló'),
(99, 'Methotrexat', 19, 'Autoimmun gyógyszer', '1 tabletta hetente', '08:00', '2024-06-10', '2024-07-10', '2024-06-25', 'Autoimmun betegségek kezelésére'),
(100, 'Azathioprin', 20, 'Autoimmun gyógyszer', '1 tabletta naponta', '09:00', '2024-06-11', '2024-07-11', '2024-06-26', 'Immunszuppresszáns terápia');

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
  `OrvosId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `receptek`
--

INSERT INTO `receptek` (`Id`, `PaciensId`, `GyogyszerId`, `OrvosId`) VALUES
(1, 1, 5, 3),
(2, 2, 12, 1),
(3, 3, 8, 4),
(4, 4, 15, 2),
(5, 5, 22, 6),
(6, 6, 30, 5),
(7, 7, 18, 8),
(8, 8, 25, 7),
(9, 9, 3, 9),
(10, 10, 10, 10);

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
  ADD CONSTRAINT `receptek_ibfk_2` FOREIGN KEY (`GyogyszerId`) REFERENCES `gyogyszer_adatok` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receptek_ibfk_3` FOREIGN KEY (`OrvosId`) REFERENCES `orvosok` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receptek_ibfk_4` FOREIGN KEY (`PaciensId`) REFERENCES `paciensek` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
