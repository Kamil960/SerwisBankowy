@extends('main', ["title" => "Artykuł Trzeci"])
@section('style')
<link rel="stylesheet" href="/css/artEdit.css" asp-append-version="true" />
@endsection
@section('content')
<h1>Edycja Trzeciego Artykułu Strony Głównej</h1>
<hr />
<div class="section-3">
	<form method="post" action="/artykul3/aktualizacja/{{$Art3->IdArt3}}">
		@csrf
			<p class="p-1">
				<label class="control-label">Tytuł</label>
				<input class="form-control" name="Tytul" value="{{$Art3->Tytul}}" />
			</p>
			<div class="cont">
				<div class="cont-img">
					<textarea class="form-control-desc" name="Grafika">{{$Art3->Grafika}}</textarea>
				</div>
				<div class="wr-cont">
					<p>
						<textarea name="Tresc1" class="form-control-desc">{{$Art3->Tresc1}}</textarea>
					</p>
					<ol>
						<li>
							<input name="PozycjaG1" class="form-control" value="{{$Art3->PozycjaG1}}" />
						</li>
						<li>
							<input name="PozycjaG2" class="form-control" value="{{$Art3->PozycjaG2}}"/>
						</li>
						<li>
							<input name="PozycjaG3" class="form-control" value="{{$Art3->PozycjaG3}}"/>
						</li>
						<li>
							<input name="PozycjaG4" class="form-control" value="{{$Art3->PozycjaG4}}"/>
						</li>
					</ol>
				</div>
				<p class="pl-cont">
					<textarea name="Tresc2" class="form-control-desc">{{$Art3->Tresc2}}</textarea>
				</p>
				<p class="cr-title">
					<input name="CrypTytul" class="form-control" value="{{$Art3->Tresc3}}" />
				</p>
				<div class="crypto">
					<div class="cr-card">
						<div class="cr-icon">
							<textarea name="CrypoIcon1" class="form-control-desc">{{$Art3->CrypoIcon1}}</textarea>
						</div>
						<p>
							<input name="CrypoTytul1" class="form-control" value="{{$Art3->CrypoTytul1}}"/>
						</p>
					</div>
					<div class="cr-card">
						<div class="cr-icon">
							<textarea name="CrypoIcon2" class="form-control-desc">{{$Art3->CrypoIcon2}}</textarea>
						</div>
						<p>
							<input name="CrypoTytul2" class="form-control" value="{{$Art3->CrypoTytul2}}"/>
						</p>
					</div>
					<div class="cr-card">
						<div class="cr-icon">
							<textarea name="CrypoIcon3" class="form-control-desc">{{$Art3->CrypoIcon3}}</textarea>
						</div>
						<p>
							<input name="CrypoTytul3" class="form-control" value="{{$Art3->CrypoTytul3}}"/>
						</p>
					</div>
					<div class="cr-card">
						<div class="cr-icon">
							<textarea name="CrypoIcon4" class="form-control-desc">{{$Art3->CrypoIcon4}}</textarea>
						</div>
						<p>
							<input name="CrypoTytul4" class="form-control" value="{{$Art3->CrypoTytulTytul4}}"/>
						</p>
					</div>
				</div>
				<div class="form-group-btn-edit">
					<input type="submit" value="Edytuj" class="button-edit" />
					<a class="button-edit" href="/artykul3">Powrót</a>
				</div>
			</div>

		</form>
</div>
@endsection