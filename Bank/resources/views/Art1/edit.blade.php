@extends('main', ["title" => "Artykuł Pierwszy"])
@section('style')
<link rel="stylesheet" href="/css/artEdit.css" asp-append-version="true" />
@endsection
@section('content')
<h1>Edycja Artykułu Pierwszego Strony Głównej</h1>

<hr/>
<div class="section-1-edit">
	<form method="post" action="/artykul1/aktualizacja/{{$Art1->IdArt1}}">
	@csrf
		<p class="p-1">
			<label>Tytuł</label>
			<input name="Tytul" value="{{$Art1->Tytul}}" class="form-control" />
		</p>
		<div class="id-cards-field">
			<div class="id-card">
				<label class="control-label">Nazwa:</label>
				<h2>
					<input name="Nazwa1" value="{{$Art1->Nazwa1}}" />
				</h2>
				<label class="control-label">Grafika:</label>
				<textarea class="form-control-desc" name="Grafika1">{{$Art1->Grafika1}}</textarea>
				<label class="control-label">Opis:</label>
				<textarea class="form-control" name="Opis1">{{$Art1->Opis1}}</textarea>
			</div>
			<div class="id-card">
				<label class="control-label">Nazwa:</label>
				<h2>
					<input name="Nazwa2" value="{{$Art1->Nazwa2}}" />
				</h2>
				<label class="control-label">Grafika:</label>
				<textarea class="form-control-desc" name="Grafika2">{{$Art1->Grafika2}}</textarea>
				<label class="control-label">Opis:</label>
				<textarea class="form-control" name="Opis2">{{$Art1->Opis2}}</textarea>
			</div>
			<div class="id-card">
				<label class="control-label">Nazwa:</label>
				<h2>
					<input name="Nazwa3" value="{{$Art1->Nazwa3}}"/>
				</h2>
				<label class="control-label">Grafika:</label>
				<textarea class="form-control-desc" name="Grafika3">{{$Art1->Grafika3}}</textarea>
				<label class="control-label">Opis:</label>
				<textarea class="form-control" name="Opis3">{{$Art1->Opis3}}</textarea>
			</div>
		</div>
		<p class="p-3">
			<label class="control-label">Podsumowanie</label>
			<input value="{{$Art1->Podsumowanie}}" class="form-control" name="Podsumowanie"/>
			<span for="{{$Art1->Podsumowanie}}" class="text-danger"></span>
		</p>
		<div class="form-group-btn-edit">
			<input class="button-edit" type="submit" value="Edytuj"  />
			<a class="button-edit" href="/artykul1">Powrót</a>
		</div>
	</form>
</div>
@endsection