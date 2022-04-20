<?php
include('funkcje.php');
?>
<html style="font-size: 16px;">
<head>
  <meta charset="utf-8">
  <title>Nowy przelew</title>
  <link rel="stylesheet" href="nicepage.css" media="screen">
    <link rel="stylesheet" href="Przelew.css" media="screen">
    <link id="u-theme-google-font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i">
  </head>
  <body class="u-body"><header class="u-clearfix u-header u-header" id="sec-323c"><div class="u-clearfix u-sheet u-sheet-1">
        <a class="u-image u-logo u-image-1" data-image-width="700" data-image-height="350">
          <img src="images/logo.png" class="u-logo-image u-logo-image-1">
        </a>
        <button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Wyloguj " onClick="window.location='Logowanie.php'">Wyloguj</button>
      </div></header>
	  <section class="u-clearfix u-palette-1-dark-2 u-section-1" id="sec-11eb">
      <div class="u-clearfix u-sheet u-sheet-1">
	  <?php
		$idU = 0;
		if(empty($_POST['odbiorca']) && empty($_POST['nrRach']) && empty($_POST['kwota'])&& empty($_POST['tytul'])) {
			echo "";
			$data = time();
	 ?>
	<form class="form1" method=POST action=''> 
	<p class="p1"> Dane do przelewu</p>
		<table class="table1" >
		<tr>
		<td>Odbiorca</td><td colspan=2><input class="input1" type=text name='odbiorca' required pattern="[A-Za-z ]{1,65}" autocomplete="off"></td>
		</tr>
        <tr>
		<td>Numer konta odbiorcy</td><td colspan=2><input class="input1" type=text name='nrRach' required pattern="[0-9]{26}"></td>
		</tr>
		<tr>
		<td>Tytuł</td><td colspan=2><input class="input1" name='tytul' required pattern="[A-Za-z0-9]{1,65}" autocomplete="off"></td>
		</tr>
		<td>Kwota</td><td colspan=2><input class="input1" type=text name='kwota' required pattern="[0-9]{1,32}" autocomplete="off"></td>
		</tr>
		<tr>
		<td ><button class="button1" type=button value='Powrót' onClick="window.location='Główna.php'" >Powrót</td>
		<td ><input class="input3" type=submit value='Zatwierdzam'></td>
		</tr>
		</table>
	</form>
<?php
	}
	else {
		session_start();
		$odb = $_POST["odbiorca"];
		$nad = $_SESSION["imie"]." ".$_SESSION["nazwisko"];
		$nr = $_POST["nrRach"];
		$kwota = $_POST["kwota"];
		$tytul = $_POST["tytul"];
		$data = date("Y-m-d H:i:s");
		
		otworz_polaczenie();
        global $polaczenie;
		
		$zapytanie1 = "INSERT INTO operacje  VALUES ('$nad', '$odb', 'przelew', '$kwota', '$data')";
		$wynik = mysqli_query($polaczenie, $zapytanie1)
		or exit ("Nieprawidłowe zapytanie"); 
		
		 mysqli_close($polaczenie); 
		
		 echo "<div>";
		 echo "<a href='Główna.php'> Przelew został przekazany do realizacji</a>";
		 echo "<a href='Główna.php'> Powrót </a>";
		 echo "</div>";
			}
		?>
	  </div>
    </section>
	<footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-3f9f"><div class="u-align-left u-clearfix u-sheet u-sheet-1"></div></footer>
</body>
</html>