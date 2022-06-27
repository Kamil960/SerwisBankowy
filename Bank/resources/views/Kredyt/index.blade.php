@extends('main', ["title" => "Kredyt"])
@section('style')
<link rel="stylesheet" href="/css/OfertaOsobista.css"/>
@endsection
@section('content')
<p class="title">
	<label>Dostępne oferty</label>
</p>
<div class="conteiner">
	<div class="row row-cols-1 row-cols-md-3 g-4">
		@foreach ($Kredyt as $kredyt)		
			<div class="col">
				<div class="d-flex justify-content-center">
					<div class="card position-relative">
						<a class="btn-choice" href="\kredyt\edycja\{{$kredyt->IdKredyt}}">
							<h4 class="btn-header">{{$kredyt->Nazwa}}</h4>
							<img class="btn-icon" src="{{$kredyt->Grafika}}" alt="https://img.freepik.com/darmowe-wektory/kreskowka-banka-retro-budynek-lub-gmach-sadu-z-kolumny-ilustracja-odizolowywajaca-na-bielu_53562-8133.jpg" />
							<p class="btn-description">{{$kredyt->Opis}}</p>
							<hr/>
							<p class="btn-description">Oprocentowanie:</p>
							<p class="btn-description">{{$kredyt->Procent}}%</p>
						</a>
						<div class="del">
							<a class="del-btn" href="/kredyt/usuwanie/{{$kredyt->IdKredyt}}">
								<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-archive" viewBox="0 0 16 16">
									<path d="M0 2a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1v7.5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 12.5V5a1 1 0 0 1-1-1V2zm2 3v7.5A1.5 1.5 0 0 0 3.5 14h9a1.5 1.5 0 0 0 1.5-1.5V5H2zm13-3H1v2h14V2zM5 7.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5z" />
								</svg>
							</a>
						</div>
					</div>
				</div>
			</div>
		@endforeach
		<p class="add">
			<a style="text-decoration: none" href="/kredyt/dodawanie">
				<svg src="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle" viewBox="0 0 16 16">
					<path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
					<path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z" />
				</svg>
			</a>
		</p>
	</div>
</div>
@endsection