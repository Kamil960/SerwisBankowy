<!DOCTYPE html>
<html lang="pl">
<head>
	<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/5.0.0-alpha1/css/bootstrap.min.css" asp-append-version="true">
	<link id="u-theme-google-font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i">
	<link id="u-page-google-font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Merriweather:300,300i,400,400i,700,700i,900,900i">
	<link rel="stylesheet" href="/css/site.css" asp-append-version="true" />
	<link rel="stylesheet" href="/css/art.css" asp-append-version="true" />
	@yield('style')
</head>
<body>
	<section class="app">
		<aside class="sidebar">
			<header>Menu</header>
			<nav class="sidebar-nav">
				<ul>
					<li>
						<a href="#"><img class="intra-icon" src='/Icons/content.png'> <span>Zarządzanie portalem</span></a>
						<ul class="nav-flyout">
							<li>
								<a href="/artykul1"><img class="intra-icon2" src='/Icons/pages.png'>Artukuł Pierwszy</a>
							</li>
							<li>
								<a href="/artykul2"><img class="intra-icon2" src='/Icons/offer.png'>Artykuł Drugi</a>
							</li>
							<li>
								<a href="/artykul3"><img class="intra-icon2" src='/Icons/art.png'>Artykuł Trzeci</a>
							</li>
							<li>
								<a href="/kontakt"><img class="intra-icon2" src='/Icons/contact.png'>Kontakt</a>
							</li>
							<li>
								<a href="/onas"><img class="intra-icon2" src='/Icons/info.png'>O nas</a>
							</li>
						</ul>
					</li>
					<li>
						<a href="#"><img class="intra-icon" src='/Icons/edit.png'> <span class="">Edytuj oferty</span></a>
						<ul class="nav-flyout">
							<li>
								<a href="/kontoOsobiste"><img class="intra-icon2" src='/Icons/user.png'>Konto Osobiste</a>
							</li>
							<li>
								<a href="/kredyt"><img class="intra-icon2" src='/Icons/user.png'>Kredyt</a>
							</li>
							<li>
								<a href="/lokata"><img class="intra-icon2" src='/Icons/user.png'>Lokata</a>
							</li>
							<li>
								<a href="/ubezpieczenie"><img class="intra-icon2" src='/Icons/user.png'>Ubezpieczenie</a>
							</li>
						</ul>
					</li>
				</ul>
			</nav>
		</aside>
		<div class="main-box">
			<main role="main" class="pb-3">
				@yield('content')
			</main>
		</div>
	</section>
	<footer class="border-top footer text-muted">
	</footer>
	<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
	<script src="~/lib/jquery/dist/jquery.min.js"></script>
	<script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
	<script src="~/js/site.js" asp-append-version="true"></script>
</body>
</html>