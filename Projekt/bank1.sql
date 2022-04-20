-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 30 Sty 2022, 12:45
-- Wersja serwera: 10.4.22-MariaDB
-- Wersja PHP: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `bank1`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `karty`
--

CREATE TABLE `karty` (
  `Login` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Numer` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Rodzaj` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Kolor` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `DataWażności` date DEFAULT NULL,
  `KodCVV` varchar(3) COLLATE utf8_polish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `karty`
--

INSERT INTO `karty` (`Login`, `Numer`, `Rodzaj`, `Kolor`, `DataWażności`, `KodCVV`) VALUES
('Kamis', '6767 4665 3673  8095', 'debetowa', 'czarna', '2022-01-30', '647'),
('Cypis', '6767 6681 4399  2241', 'kredytowa', 'złota', '2022-01-30', '872');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `operacje`
--

CREATE TABLE `operacje` (
  `Nadawca` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Odbiorca` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Rodzaj` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Wartość` double DEFAULT NULL,
  `DataWykonania` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `operacje`
--

INSERT INTO `operacje` (`Nadawca`, `Odbiorca`, `Rodzaj`, `Wartość`, `DataWykonania`) VALUES
('Kamil Szostek', 'Mateusz Szostek', 'przelew', 100, '2022-01-30');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `użytkownik`
--

CREATE TABLE `użytkownik` (
  `Login` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Hasło` varchar(255) COLLATE utf8_polish_ci DEFAULT NULL,
  `Imie` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `Nazwisko` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL,
  `DataUrodzenia` date DEFAULT NULL,
  `Płeć` varchar(1) COLLATE utf8_polish_ci DEFAULT NULL,
  `NumerRachunku` varchar(32) COLLATE utf8_polish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `użytkownik`
--

INSERT INTO `użytkownik` (`Login`, `Hasło`, `Imie`, `Nazwisko`, `DataUrodzenia`, `Płeć`, `NumerRachunku`) VALUES
('Cypis', '$2y$10$Y4lGEkkuRpHPF0icy92Id.5CE01GoZiMvMvUg7NwtveDG1G4XOKyG', 'Cyprian', 'Norwid', '1787-07-12', 'm', '14 7676 1234 66814399 0000 0000');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
