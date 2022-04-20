<?php

function otworz_polaczenie(){
	global $polaczenie;
	$serwer = "127.0.0.1";
	$uzytkownik = "root";
	$haslo = "";
	$baza = "bank1";

	$polaczenie = mysqli_connect($serwer, $uzytkownik, $haslo) or exit("Nieudane połączenie z serwerem");	
	if(!mysqli_select_db($polaczenie, $baza)) {
		if(mysqli_errno($polaczenie) == 1049) {
			utworz_baze();
			mysqli_select_db($polaczenie, $baza);
			utworz_tabele();
		}
		else echo("Połączenie z bazą danych $baza nieudane<br>");
	}
	mysqli_set_charset($polaczenie, "utf8");
}

function zamknij_polaczenie(){
	global $polaczenie;
	mysqli_close($polaczenie);
}

function utworz_baze() {
	$polaczenie = mysqli_connect("127.0.0.1", "root", "") or exit("Nieudane połączenie z serwerem");
	$baza = 'bank1';
	
	mysqli_query($polaczenie, "CREATE DATABASE `$baza` DEFAULT CHARACTER SET utf8 COLLATE utf8_polish_ci;") 
	or exit("Błąd w zapytaniu tworzącym bazę");
}

function utworz_tabele() {
	global $polaczenie;
	$rozkaz = 	"create table przedmioty " .
				"(numer int NOT NULL AUTO_INCREMENT ," .
				"nazwa varchar(32), " .	
				"godzin int, PRIMARY KEY (`numer`))";

	$utworz = 	"Create Table użytkownik " .
				"(Login varchar(32), " .
				"Hasło varchar(255), " .	
				"Imie varchar(32), " .
				"Nazwisko varchar(32), " .
				"DataUrodzenia DATE , " .	
				"Płeć varchar(1), " .			
				"NumerRachunku varchar(32) )";
	mysqli_query($polaczenie, $utworz) or exit("Niepoprawne zapytanie: $utworz");
	
	$utworz = 	"create table operacje " .
				"(Nadawca varchar(32), " .
				"Odbiorca varchar(32), " .	
				"Rodzaj varchar(32), " .	
				"Wartość double, " .
				"DataWykonania date )";
	mysqli_query($polaczenie, $utworz) or exit("Niepoprawne zapytanie: $utworz");
	
	$utworz = 	"create table karty " .
				"(Login varchar(32), " .
				"Numer varchar(32), " .
				"Rodzaj varchar(32), " .
				"Kolor varchar(32), " .	
				"DataWażności date, " .
				"KodCVV varchar(3) )";
	mysqli_query($polaczenie, $utworz) or exit("Niepoprawne zapytanie: $utworz");
}

?>