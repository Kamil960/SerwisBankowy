@extends('main', ["title" => "Kontakt"])
@section('style')
<link rel="stylesheet" href="/css/contact.css" asp-append-version="true" />
@endsection
@section('content')
<h1>Edycja Strony Kontaktowej</h1> 
	@foreach($Kontakt as $kontakt)
	<a href="/kontakt/edycja/{{$kontakt->IdKontakt}}">
		<div class="field1">
			<h2 class="title">{{$kontakt->Tytul}}</h2>
			<div class="cloud1">
				<h3 class="cloudname">{{$kontakt->Opis}}</h3>
				<p class="content1">{{$kontakt->Adres}}</p>
			</div>

			<div class="cloud2">
				<h3 class="cloudname cloudname2">Telefon</h3>
				<p class="content2">{{$kontakt->Opis2}}<br/> {{$kontakt->NrTelStacjonarny}}</p>
				<p class="content2">{{$kontakt->Opis3}} <br/>{{$kontakt->NrTelKomorkowy}}</p>
			</div>

			<div class="cloud3">
				<h3 class="cloudname">{{$kontakt->Opis4}}</h3>
				<p class="content3">{{$kontakt->Email}}</p>
			</div>
		</div>
	</a>
	@endforeach
@endsection