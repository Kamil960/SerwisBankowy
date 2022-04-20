<html style="font-size: 16px;">
<head>
  <meta charset="utf-8">
  <title>Nowa karta</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
    <link rel="stylesheet" href="Karta.css" media="screen">
  </head>

  <body class="u-body"><header class="u-clearfix u-header u-header" id="sec-323c"><div class="u-clearfix u-sheet u-sheet-1">
        <a class="u-image u-logo u-image-1" data-image-width="700" data-image-height="350">
          <img src="images/logo.png" class="u-logo-image u-logo-image-1">
        </a>
        <button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Wyloguj " onClick="window.location='Logowanie.php'">Wyloguj</button>
      </div></header>
    <section class="u-clearfix u-palette-1-dark-2 u-section-1" id="sec-1823">
      <div class="u-clearfix u-sheet u-sheet-1">
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

if(isset($_POST['nick']))
{
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
      echo "<div>";
			echo "<div> Przyjęto zlecenie wydania nowej karty płatniczej.<br>
      Czas oczekiwania na karte wynosi do 7 dni roboczych, kod pin zostanie wysłany oddzielną przesyłką.</div>";
			echo "<a href='Główna.php'> Powrót </a>";
			echo "</div>";
}
else {
?>
      <form class="form1" method=POST action=''> 
      <table class="table1" >
		<tr>
		<td>Wybierz rodzaj karty</td>
		</tr>
    <tr>
		<td>
      <select class="select1" name='rodzaj'>
        <option value='debetowa'>debetowa</option>
        <option value='kredytowa'>kredytowa</option>
     </select></td>
		</tr>

    <tr>
		<td>Wybierz kolor karty</td>
		</tr>
		<tr>
		<td><label class="label1">
          <input class="input2" type="radio" name='color' value="czarna" checked>
          <img src="https://centrum.meble.pl/gfx/meble/sklep_kategorie/260/5834/618762892.jpg" alt="Czarny" width="30" height="30">
        </label>
        <label class="label1"> 
          <input class="input2" type="radio" name="color" value="biała">
          <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAJoAAAFICAMAAACfoBe1AAAAA1BMVEX///+nxBvIAAAASElEQVR4nO3BMQEAAADCoPVP7WsIoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB4A8aYAAGMlEOkAAAAAElFTkSuQmCC" alt="Czarny" width="30" height="30">
        </label>
        <br>
        <label class="label1">
          <input class="input2" type="radio" name="color" value="złota">
          <img src="https://img.freepik.com/darmowe-zdjecie/zloty-kolor-gradientu-tla-dla-kreatywnych-streszczenie-tlo_120819-120.jpg?size=626&ext=jpg" alt="Czarny" width="30" height="30">
        </label>
        <label>
          <input class="input2" type="radio" name="color" value="szara">
          <img src="https://magdalena24.pl/userdata/public/gfx/61699/Tkanina-dekoracyjna.jpg" alt="Czarny" width="30" height="30">
        </label>
    </td>
		</tr>
    <tr>
		<td>Podaj nick który zostanie dopisany na karcie:</td><td><input class="input1" type=text name='nick' required pattern="[A-Za-z]{1,32}" autocomplete="off"></td>
		</tr>
    <tr>
		  <td class="td1"><button class="button1" value=" Powrót " onClick="window.location='Główna.php'">Powrót</button></td>
      <td class="td1"><input class="input3" type=submit value="Dodaj"></td>
		</tr>
</table>
	</form>
  <?php } ?>
</div>
</section>
</body>
<footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-3f9f"><div class="u-align-left u-clearfix u-sheet u-sheet-1"></div></footer>
</html>