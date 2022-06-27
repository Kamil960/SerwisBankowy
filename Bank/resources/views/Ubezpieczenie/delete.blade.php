@extends('main', ["title" => "Ubezpieczenie"])
@section('style')
<link rel="stylesheet" href="/css/UsunOferte.css"/>
@endsection
@section('content')
<div class="card display-flex">
	<h3 class="h3">Czy napewno chcesz usunąć wybraną ofertę?</h3>
		<form class="form" method="get" action="/ubezpieczenie/usun/{{$Ubezpieczenie->IdUbezpieczenie}}">
		@csrf
			<button type="submit" value="Delete" class="btn btn-danger">Usuń</button> 
			<a href="\ubezpieczenie" class="btn btn-primary">Powrót</a>
		</form>
</div>
@endsection