@extends('main', ["title" => "Artykuł Drugi"])
@section('style')
<link rel="stylesheet" href="/css/artEdit.css" asp-append-version="true" />
@endsection
@section('content')
<h1>Edycja Artykułu Drugiego Strony Głównej</h1>
<hr />

<div class="section-2">
<form method="post" action="/artykul2/aktualizacja/{{$Art2->IdArt2}}">
	@csrf
		<p class="p-1">
			<label class="control-label"></label>
			<input name="Tytul" value="{{$Art2->Tytul}}" class="form-control" />
		</p>
		<div class="cont">
			<div class="class=" p-3"">
				<textarea name="Tresc1" class="form-control-desc">{{$Art2->Tresc1}}</textarea>
			</div>
			<div class="p-31">
				<textarea name="Tresc2" class="form-control-desc">{{$Art2->Tresc2}}</textarea>
			</div>
			<div class="art2-img">
				<textarea name="Grafika" class="form-control-desc">{{$Art2->Grafika}}</textarea>
			</div>
		</div>
		<div class="form-group-btn-edit">
			<input class="button-edit" type="submit" value="Edytuj"/>
			<a class="button-edit" href="/artykul2" >Powrót</a>
		</div>
	</form>
</div>
@endsection