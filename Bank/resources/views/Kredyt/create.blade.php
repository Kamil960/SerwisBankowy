@extends('main', ["title" => "Kredyt"])
@section('style')
<link rel="stylesheet" href="/css/edit-list-style.css"/>
@endsection
@section('content')
<h1>Dodawanie oferty Kredytu</h1>
<hr />
<div class="form-body">
	<div class="row">
		<div class="form-holder">
			<div class="form-content">
				<div class="form-items">
					<form method="post" action="\kredyt\dodaj">
					@csrf
						<div class="form-group">
							<label class="control-label">Nazwa</label>
							<input name="Nazwa" class="form-control" />
						</div>
						<div class="form-group">
							<label class="control-label">Opis</label>
							<input class="form-control-desc" name="Opis"/>
						</div>
						<div class="form-group">
							<label class="control-label">Grafika</label>
							<input name="Grafika" class="form-control"/>
						</div>
						<div class="form-group">
							<label class="control-label">Oprocentowanie</label>
							<input name="Procent" class="form-control"/>
						</div>
						<div class="form-group-btn">
							<input type="submit" value="Dodaj" class="button" />
							<a class="button" href="\kredyt">Powrót</a>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
</div>
@endsection 