<?php
 
include('funkcje.php');

function numer()
{
    $pierwsze = "6767";
    $drugie = substr($_SESSION["rachunek"], 13, 4);
    $trzecie = substr($_SESSION["rachunek"], 17, 5);
    $czwarte = mt_rand(1000, 9999);
    $numer = $pierwsze." ".$drugie." ".$trzecie." ".$czwarte;
    return $numer;
}


session_start();
$login = $_SESSION["login"];
$numer = numer();
$rodzaj = $_POST["rodzaj"];
$kolor = $_POST["color"];
$data = date("Y-m-d");
$cvv = mt_rand(100, 999);

otworz_polaczenie();
global $polaczenie;
$zapytanie1 = "INSERT INTO karty  VALUES ('$login', '$numer', '$rodzaj', '$kolor', '$data', '$cvv')";
$wynik = mysqli_query($polaczenie, $zapytanie1)
or exit ("Nieprawidłowe zapytanie"); 

 mysqli_close($polaczenie); 
?>
<html>
    <head>
    <meta charset="utf-8">
    <title>Logowanie</title>
    <link href="styleLogowanie.css" rel="stylesheet" >
    <style>
        div.logo {
            background-image: url("logo.png");
            background-size: cover;
            max-width: 25%;
            min-height: 250px;
            border: 2px solid black;
        }
        </style>
    </head>
    <body>
        <div>
         <h3>Przyjęto zlecenie wydania nowej karty płatniczej.<br>
         Czas oczekiwania na karte wynosi do 7 dni roboczych, kod pin zostanie wysłany oddzielną przesyłką.</h3>
         <a href='HistoriaOperacji.php'> Powrót </a>
        <div>
    </body>
</html>