@extends('main', ["title" => "O nas"])
@section('style')
<link rel="stylesheet" href="/css/aboutus.css" asp-append-version="true" />
@endsection
@section('content')
<h1>Strona Opisującej Polski Bank Kredytowy</h1>
@foreach($Onas as $onas)
<a href="/onas/edycja/{{$onas->IdOnas}}">
	<div class="field" style="background-image: url({{$onas->Grafika}})">
		<h2 class="title"> {{$onas->Tytul}} </h2>
		<p class="text">
		{{$onas->Opis}}
		</p>
	</div>
</a>
@endforeach
@endsection