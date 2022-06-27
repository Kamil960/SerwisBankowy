@extends('main', ["title" => "O nas"])
@section('style')
<link rel="stylesheet" href="/css/aboutus.css" asp-append-version="true" />
@endsection
@section('content')
<h1>Edycja Strony Opisującej Polski Bank Kredytowy</h1>
<hr />
<div class="field" style="background-image: url({{$Onas->Grafika}}">
<form method="post" action="\onas\aktualizacja\{{$Onas->IdOnas}}">
	@csrf
		<h2 class="title">
			<label>Tytuł</label>
			<input name="Tytul" class="form-control" value="{{$Onas->Tytul}}"/>
		</h2>
		<p class="text">
			<label class="control-label">Opis</label>
			<input name="Opis" class="form-control" value="{{$Onas->Opis}}" />
		</p>
		<p class="text">
			<label class="control-label">Grafika</label>
			<input name="Grafika" class="form-control" value="{{$Onas->Grafika}}"/>
		</p>
		<div class="form-group-btn">
			<input type="submit" value="Edytuj" class="button" />
			<a class="button" asp-action="Index">Powrót</a>
		</div>
	</form>
</div>
@endsection