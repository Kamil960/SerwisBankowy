@extends('main', ["title" => "Artykuł Drugi"])

@section('content')
<h1>Drugi Artykuł Strony Głównej</h1>
@foreach($Art2 as $art2)
<div class="section-2">
	<a href="{{ url()->current() }}/edycja/{{$art2->IdArt2}}">
		<p class="p-1">{{$art2->Tytul}}</p>
		<div class="cont">
			<img src="{{$art2->Grafika}}" />
			<p class="p-3">{{$art2->Tresc1}}</p>
			<p class="p-31">{{$art2->Tresc2}}</p>
		</div>
	</a>
</div>
@endforeach
@endsection