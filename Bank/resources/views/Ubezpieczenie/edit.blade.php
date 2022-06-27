@extends('main', ["title" => "Ubezpieczenie"])
@section('style')
<link rel="stylesheet" href="/css/edit-list-style.css"/>
@endsection
@section('content')
<h1>Edycja oferty Ubezpieczenia</h1>
<hr />
<div class="form-body">
	<div class="row">
		<div class="form-holder">
			<div class="form-content">
				<div class="form-items">
					<form method="post" action="\ubezpieczenie\aktualizacja\{{$Ubezpieczenie->IdUbezpieczenie}}">
						@csrf
						<div class="form-group">
							<label class="control-label">Nazwa</label>
							<input name="Nazwa" class="form-control" value="{{$Ubezpieczenie->Nazwa}}"/>
						</div>
						<div class="form-group">
							<label name="Opis" class="control-label"></label>
							<input class="form-control-desc" name="Opis" value="{{$Ubezpieczenie->Opis}}"/>
						</div>
						<div class="form-group">
							<label name="Grafika" class="control-label"></label>
							<input name="Grafika" class="form-control" value="{{$Ubezpieczenie->Grafika}}"/>
						</div>
						<div class="form-group-btn">
							<input type="submit" value="Edytuj" class="button" />
							<a class="button" href="\ubezpieczenie">Powrót</a>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
</div>
@endsection