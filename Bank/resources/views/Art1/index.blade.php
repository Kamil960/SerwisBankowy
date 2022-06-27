@extends('main', ["title" => "Artykuł Pierwszy"])

@section('content')
<h1>Pierwszy Artykuł Strony Głównej</h1>
<div class="section-1">
@foreach($Art1 as $art1)
	<a href="{{ url()->current() }}/edycja/{{$art1->IdArt1}}"><p class="p-1">{{$art1->Tytul}}</p>
	<div class="id-cards-field">
		<div class="id-card1">
				<h2>{{$art1->Nazwa1}}</h2>
				<img src="{{$art1->Grafika1}}" />
				<p class="p-2">{{$art1->Opis1}}</p>
		</div>
		<div class="id-card2">
				<h2>{{$art1->Nazwa2}}</h2>
				<img src="{{$art1->Grafika2}}" />
				<p class="p-2">{{$art1->Opis2}}</p>
				
		</div>
		<div class="id-card3">
				<h2>{{$art1->Nazwa3}}</h2>
				<img src="{{$art1->Grafika3}}"/>
				<p class="p-2">{{$art1->Opis3}}</p>
				
		</div>
	</div>
		<p class="p-3">{{$art1->Podsumowanie}}</p>
	</a>
@endforeach
</div>
@endsection