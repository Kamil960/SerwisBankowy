<?php
include('funkcje.php');
session_start();
function wypisz_operacje(){
	global $polaczenie;
	

	$klient = $_SESSION["imie"]." ".$_SESSION["nazwisko"];
	$zapytanie = "select * from operacje where Nadawca='$klient' || Odbiorca = '$klient';";	
	$wynik = mysqli_query($polaczenie, $zapytanie);

	if(!$wynik) return;
	$naglowki = array("Nadawca", "Odbiorca", "Rodzaj", "Wartość", "Data wykonania");
	print("<b>Historia Operacji</b><br>");
	print("<table border = 1><tr>");
	foreach($naglowki as $naglowek) print("<td><b>$naglowek</b></td>");	
    while($wiersz = mysqli_fetch_row($wynik)){		
        print("<tr>");
        foreach($wiersz as $p=>$pole)
             print("<td>$pole</td>");
    }
	print("</table>");
	mysqli_free_result($wynik);
}
function wyszukaj_operacje($szukana){
	global $polaczenie;
	
	$szukana = $_POST["szukana"];

	$klient = $_SESSION["imie"]." ".$_SESSION["nazwisko"];
	$zapytanie = "select * from operacje where Nadawca='$klient' || Odbiorca = '$klient' && DataWykonania > '$szukana';";	
	$wynik = mysqli_query($polaczenie, $zapytanie);

	if(!$wynik) return;
	$naglowki = array("Nadawca", "Odbiorca", "Rodzaj", "Wartość", "Data wykonania");
	print("<b>Historia Operacji</b><br>");
	print("<table border = 1><tr>");
	foreach($naglowki as $naglowek) print("<td><b>$naglowek</b></td>");	
    while($wiersz = mysqli_fetch_row($wynik)){		
        print("<tr>");
        foreach($wiersz as $p=>$pole)
             print("<td>$pole</td>");
    }
	print("</table>");
	mysqli_free_result($wynik);
}

function wypisz_karty(){
	global $polaczenie;

	$login = $_SESSION["login"];
	$zapytanie = "Select Numer, Rodzaj, Kolor from karty where Login='$login';";	
	$wynik = mysqli_query($polaczenie, $zapytanie)
	or exit ("Nieprawidłowe zapytanie"); 

	if(!$wynik) return;
	$naglowki = array("Numer karty", "Rodzaj", "Kolor");

		print("<b>Twoje karty płatnicze</b><br>");
		print("<table border = 1><tr>");
		foreach($naglowki as $naglowek) print("<td><b>$naglowek</b></td>");	
		while($wiersz = mysqli_fetch_row($wynik)){		
			print("<tr>");
			foreach($wiersz as $p=>$pole)
				 print("<td>$pole</td>");
			print("</tr>");		
		}
		print("</table>");
		mysqli_free_result($wynik);
}

function usun_karte($nr) {
	global $polaczenie;
	
	$zapytanie = "delete from karty where Numer='$numer';";		
	mysqli_query($polaczenie, $rozkaz) or exit("Niepoprawne zapytanie");
}

?>

<html style="font-size: 16px;">
<head>
<meta charset="utf-8">
    <title>Historia</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
    <link rel="stylesheet" href="Historia.css" media="screen">
    <link id="u-theme-google-font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i">
    <meta name="theme-color" content="#478ac9">
    <meta property="og:title" content="Historia">
    <meta property="og:type" content="website">
	<script>
		function zlaData(data) {
			dzien = data.substr(0,2);
			miesiac = data.substr(3,2);
			rok = data.substr(6,4);
			d = new Date(rok,miesiac,dzien);	
			if (dzien==d.getDate() && miesiac==d.getMonth() && rok==d.getFullYear())
				return false;
			else
				return true;
		}
		function valid() {
		if(zlaData(document.forms[0].szukana.value)) { alert("Nieprawidłowy format daty"); return false; }
		return true;
		}		
  </script>
</head>
<body class="u-body"><header class="u-clearfix u-header u-header" id="sec-323c"><div class="u-clearfix u-sheet u-sheet-1">
    <a class="u-image u-logo u-image-1" data-image-width="700" data-image-height="350">
    	<img src="images/logo.png" class="u-logo-image u-logo-image-1">
    </a>
	<span>
	<button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Główna " onClick="window.location='Główna.php'">Główna</button>
	<button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Przelew " onClick="window.location='Przelew.php'">Przelew</button>
	<button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Nowa karta " onClick="window.location='Karta.php'">Nowa karta</button>
    <button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Wyloguj " onClick="window.location='Logowanie.php'">Wyloguj</button>
    </span> 
	</div></header>
	<section class="u-clearfix u-palette-1-dark-2 u-section-1" id="sec-5f48">
      <div class="u-clearfix u-sheet u-sheet-1">
		<?php
		 if(isset($_POST["szukana"]))
		 { ?>
		<form class="form1" method=POST action=''  onSubmit='return valid();'> 
	  	<p class="p1"> Wyświetl historie operacji od: </p>
	  	<input class="input1" type="text" name='szukana' placeholder="Search.."> 
		<input value=" Szukaj " class="button1" type='submit'>
		<table class="table1">
		<?php
			$polecenie = '';

			otworz_polaczenie();
			echo "<tr><td>";
			wyszukaj_operacje($_POST["szukana"]);
			echo "</td></tr>";
			echo "<br>";
			echo "<tr><td>";
			wypisz_karty();
			echo "</td></tr>";
			zamknij_polaczenie();
			echo"</table>";
			echo"</form>";
		 }
		 else {
		?>
		<form class="form1" method=POST action=''  onSubmit='return valid();'> 
	  	<p class="p1"> Wyświetl historie operacji od: </p>
		<input class="input1" type="text" name='szukana' placeholder="Search.."> 
		<input value=" Szukaj " class="button1" type='submit'>
		<table class="table1">
		<?php
			$polecenie = '';

			otworz_polaczenie();
			echo "<tr><td>";
			wypisz_operacje();
			echo "</td></tr>";
			echo "<br>";
			echo "<tr><td>";
			wypisz_karty();
			echo "</td></tr>";
			zamknij_polaczenie();
			echo"</table>";
			echo"</form>";
		 }
		?>
	</div>
	</section>

</body>
<footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-3f9f"><div class="u-align-left u-clearfix u-sheet u-sheet-1"></div></footer>
</html>