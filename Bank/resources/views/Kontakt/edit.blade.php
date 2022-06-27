@extends('main', ["title" => "Kontakt"])
@section('style')
<link rel="stylesheet" href="/css/contactEdit.css" asp-append-version="true" />
@endsection
@section('content')
<h1>Edycja Strony Kontaktowej</h1>
<hr />
<div class="field1">
	<form method="post" action="\kontakt\aktualizacja\{{$Kontakt->IdKontakt}}">
	@csrf
		<h2 class="title">
			<label class="control-label">Dane kontaktowe</label>
		</h2>
		<div class="cloud1">
		`<h3 class="cloudname cloudname2">Adres</h3>
			<p class="content1">
				<input name="Adres" class="form-control" value="{{$Kontakt->Adres}}"/>
			</p>
		</div>

		<div class="cloud2">
			<h3 class="cloudname cloudname2">Telefon</h3>
			<p class="content2">
				<label class="control-label">Telefon Stajonarny</label>
				<input name="NrTelefonuSt" class="form-control" value="{{$Kontakt->NrTelStacjonarny}}"/>
			</p>
			<p class="content2">
				<label class="control-label">Telefon Komórkowy</label>
				<input name="NrTelefonuKom" class="form-control" value="{{$Kontakt->NrTelKomorkowy}}"/>
			</p>
		</div>
		<div class="cloud3">
			<h3 class="cloudname">
				<label class="control-label">Email</label>
			</h3>
			<p class="content3">
				<input name="Email" class="form-control" value="{{$Kontakt->Email}}"/>
			</p>
		</div>
		<div class="form-group-btn">
			<input type="submit" value="Edytuj" class="button" />
			<a class="button" href="\kontakt" >Powrót</a>
		</div>
	</form>
</div>
@endsection