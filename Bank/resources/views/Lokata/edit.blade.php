@extends('main', ["title" => "Lokata"])
@section('style')
<link rel="stylesheet" href="/css/edit-list-style.css"/>
@endsection
@section('content')
<h1>Edycja oferty Lokaty</h1>
<hr />
<div class="form-body">
	<div class="row">
		<div class="form-holder">
			<div class="form-content">
				<div class="form-items">
					<form method="post" action="\lokata\aktualizacja\{{$Lokata->IdLokata}}">
						@csrf
						<div class="form-group">
							<label class="control-label">Nazwa</label>
							<input name="Nazwa" class="form-control" value="{{$Lokata->Nazwa}}"/>
						</div>
						<div class="form-group">
							<label name="Opis" class="control-label">Opis</label>
							<input class="form-control-desc" name="Opis" value="{{$Lokata->Opis}}"/>
						</div>
						<div class="form-group">
							<label class="control-label">Oprocentowanie</label>
							<input name="Oprocentowanie" class="form-control" value="{{$Lokata->Procent}}"/>
						</div>
						<div class="form-group">
							<label class="control-label">Grafika</label>
							<input name="Grafika" class="form-control" value="{{$Lokata->Grafika}}"/>
						</div>
						<div class="form-group-btn">
							<input type="submit" value="Edytuj" class="button" />
							<a class="button" href="\lokata">Powrót</a>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
</div>
@endsection