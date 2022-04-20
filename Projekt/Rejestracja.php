<?php
include("funkcje.php");
function numerRachunku()
{
	$min = 10000000;
	$max = 99999999;
	$nrKlienta = mt_rand($min, $max);
	$nrBanku = "7676 1234";
	$zera = "0000 0000";
	$nrKontrolny = strval(mt_rand(10, 19));
	$nrRachunku = $nrKontrolny." ".$nrBanku." ".$nrKlienta." ".$zera;
	return $nrRachunku;
}
?>
<html style="font-size: 16px;">
  <head>
  	<meta charset="utf-8">
  	<title>Rejestracja</title>
    <title>Rejestracja</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
	<link rel="stylesheet" href="Rejestracja.css" media="screen">
    <link id="u-theme-google-font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i">
  </head>

  <body class="u-body"><header class="u-clearfix u-header u-header" id="sec-323c"><div class="u-clearfix u-sheet u-sheet-1">
        <a class="u-image u-logo u-image-1" data-image-width="700" data-image-height="350">
          <img src="images/logo.png" class="u-logo-image u-logo-image-1">
        </a>
        <button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Wyloguj " onClick="window.location='Logowanie.php'">Zaloguj się</button>
      </div></header>
    <section class="u-clearfix u-palette-1-dark-2 u-section-1" id="sec-704a">
	<div class="u-clearfix u-sheet u-sheet-1">
<?php
	if(empty($_POST['login']) && empty($_POST['imie']) && empty($_POST['nazwisko']) && empty($_POST['plec']) && empty($_POST['haslo'])) {
?>
	<form method=POST action='' class="form1"> 
		<p class="p1"> Proszę uzupełnić formularz:</p>
		<table class="table1" >
		<tr>
		<td>Login:</td><td colspan=2><input class="input1" type=text name='login' placeholder="Podaj login" autocomplete="off" required pattern="[A-Za-z0-9]{5,32}"></td>
		</tr>
        <tr>
		<td>Hasło:</td><td colspan=2><input class="input1" placeholder="Podaj hasło" type=password name='haslo' autocomplete="off" required pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"></td>
		</tr>
		<tr>
		<td>Imie:</td><td colspan=2><input class="input1" placeholder="Podaj imie" name='imie' autocomplete="off" required pattern="[A-Za-z]{1,32}"></td>
		</tr>
		<td>Nazwisko:</td><td colspan=2><input class="input1" placeholder="Podaj nazwisko" type=text name='nazwisko' autocomplete="off" required pattern="[A-Za-z]{1,32}"></td>
		</tr>
        <tr>
		<td>Data urodzenia:</td><td colspan=2><input class="input1" type=date name='dataUrodzenia' autocomplete="off" required></td>
		</tr>
		<tr>
		<td>Płeć:</td><td colspan=2><input class="input1" placeholder="Podaj płeć" type=text name='plec' autocomplete="off" required pattern="[k m]{1}"></td>
		</tr>
		<tr>
		<td><br></td>
		</tr>
		<tr>
		<td colspan=2><input class="input1" type=submit value='Załóż konto' style='width:100%'></td>
		</tr>
		</table>
	</form>
<?php
}
else {
		$log = $_POST["login"];
		$imie = $_POST["imie"];
		$nazwisko = $_POST["nazwisko"];
		$plec = $_POST["plec"];
        $dataUrodzenia = $_POST["dataUrodzenia"];
		$haslo = $_POST["haslo"];
		$haslo1 = password_hash($haslo, PASSWORD_DEFAULT);
		$nrRachunku = numerRachunku();
		
		otworz_polaczenie();
        global $polaczenie;
        
		$zapytanie1 = "INSERT INTO użytkownik VALUES ('$log', '$haslo1', '$imie', '$nazwisko', '$dataUrodzenia', '$plec', '$nrRachunku')";
		$wynik = mysqli_query($polaczenie, $zapytanie1)
		or exit ("Nieprawidłowe zapytanie"); 
		
		 mysqli_close($polaczenie); 
		$div1 = "div1";
		 echo "<div class=".$div1.">";
		 echo "<div> Rejestracja powiodła się</div>";
		 echo "<a href='Logowanie.php'> Zaloguj się </a>";
		 echo "</div>";
	}
?>
</div>
    </section>	
	<footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-3f9f"><div class="u-align-left u-clearfix u-sheet u-sheet-1"></div></footer>
</body>
</html>