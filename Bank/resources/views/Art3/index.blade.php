@extends('main', ["title" => "Artykuł Trzeci"])

@section('content')
<h1>Trzeci Artykuł Strony Głównej</h1>

<div class="section-3">
@foreach($Art3 as $art3)
	<a href="{{ url()->current() }}/edycja/{{$art3->IdArt3}}">
		<p class="p-1">{{$art3->Tytul}}</p>
		<div class="cont">
			<img class="cont-img" src="{{$art3->Grafika}}" />
			<div class="wr-cont">
				<p>{{$art3->Tresc1}}</p>
				<ol>
					<li>{{$art3->PozycjaG1}}</li>
					<li>{{$art3->PozycjaG2}}</li>
					<li>{{$art3->PozycjaG3}}</li>
					<li>{{$art3->PozycjaG4}}</li>
				</ol>
			</div>
			<p class="pl-cont">{{$art3->Tresc2}}</p>
			<p class="cr-title">{{$art3->Tresc3}}</p>
			<div class="crypto">
				<div class="cr-card">
					<img class="cr-icon" src="{{$art3->CrypoIcon1}}" />
					<p>{{$art3->CrypoTytul1}}</p>
				</div>
				<div class="cr-card">
					<img class="cr-icon" src="{{$art3->CrypoIcon2}}" />
					<p>{{$art3->CrypoTytul2}}</p>
				</div>
				<div class="cr-card">
					<img class="cr-icon" src="{{$art3->CrypoIcon3}}" />
					<p>{{$art3->CrypoTytul3}}</p>
				</div>
				<div class="cr-card">
					<img class="cr-icon" src="{{$art3->CrypoIcon4}}" />
					<p>{{$art3->CrypoTytul4}}</p>
				</div>
			</div>
		</div>
	</a>
	@endforeach
</div>
@endsection