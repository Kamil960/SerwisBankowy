<html style="font-size: 16px;">
<head>
  <meta charset="utf-8">
  <title>Logowanie</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
    <link rel="stylesheet" href="Logowanie.css" media="screen">
    <link id="u-theme-google-font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i">
	<script>
	function valid() {
	 if(document.forms[0].nazwisko.value == '') { alert("Nie podano nazwiska"); return false; }
	 if(document.forms[0].imie.value == '') { alert("Nie podano imienia"); return false; }
	 return true;
	}		
  </script>
</head>
<body class="u-body"><header class="u-clearfix u-header u-header" id="sec-323c"><div class="u-clearfix u-sheet u-sheet-1">
        <a class="u-image u-logo u-image-1" data-image-width="700" data-image-height="350">
          <img src="images/logo.png" class="u-logo-image u-logo-image-1">
        </a>
        <button class="u-border-2 u-border-palette-4-base u-btn u-btn-round u-button-style u-hover-palette-2-base u-radius-6 u-text-body-color u-text-hover-white u-white u-btn-1" value=" Wyloguj " onClick="window.location='Rejestracja.php'">Załóż konto</button>
      </div></header>
    <section class="u-align-center u-clearfix u-palette-1-dark-2 u-section-1" id="sec-c68b" height:700>
	<div class="u-clearfix u-sheet u-sheet-1">
	<?php
	if(isset($_POST['login'])) {
		$serwer = mysqli_connect("localhost", "root", "")
		or exit("Nie można połączyć się z serwerem bazy danych");
 
		$baza = mysqli_select_db($serwer, "bank1")
		or exit ("Nie mozna połączyć się z bazą banku"); 
		 
		mysqli_set_charset($serwer, "utf-8");
		$haslo = $_POST['haslo'];
		$login = $_POST['login'];	

		$zapytanie1 = "Select * from użytkownik where Login = '$login'";
		$dane = mysqli_query($serwer, $zapytanie1)
		or exit ("Nieprawidłowe zapytanie"); 

		$wiersz = mysqli_fetch_array($dane, MYSQLI_NUM);
		
		if(empty($wiersz[0])) 
			$znaleziony = false;  
		else	
			$znaleziony = true;
		
		if($znaleziony)
			if(password_verify($haslo, "$wiersz[1]"))
				{
					session_start();
					$_SESSION['login'] = $wiersz[0];
					$_SESSION['nazwisko'] = $wiersz[3];
					$_SESSION['imie'] = $wiersz[2];
					$_SESSION['rachunek'] = $wiersz[6];
					header("Location: Główna.php?" . SID);
					exit();				
				}
			else {
					echo "<div>Nieprawidłowe hasło</div> ";
					echo "<a href='Logowanie.php'> Spróbuj ponownie </a>";
			}
		else
		{
			echo "<div>";
			echo "<div> Podano niepoprawną nazwę użytkownika</div>";
			echo "<a href='Logowanie.php'> Spróbuj ponownie </a>";
			echo "</div>";
		}
		 
		
		 mysqli_free_result($dane); 
		 mysqli_close($serwer); 
	}
	else {
?>
	<form method=POST action='' class="form1"> 
		<table class="table1" >
		<tr>
		<td>Login</td><td colspan=2><input class="input" type=text name='login' autofocus autocomplete="off" required placeholder="Wpisz login"></td>
		</tr>
		<tr>
		<td>Hasło</td><td colspan=2><input class="input" type=password name='haslo' required placeholder="Wpisz hasło"></td>
		</tr>
		<tr>
		<td></td>
		<td colspan=2><input class="input" type=submit value='Zaloguj się' style='width:100%'></td>
		</tr>
		</table>
		</form>
		<div class="div1">
			<a class="a1" href='Rejestracja.php'> Jeśli nie masz dostępu ZAŁÓŻ KONTO </a> 
		</div>
	</div>
	
	<?php 
} 
	?> 
	
    </section>
    
    <footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-3f9f"><div class="u-align-left u-clearfix u-sheet u-sheet-1"></div></footer>
</body>
</html>