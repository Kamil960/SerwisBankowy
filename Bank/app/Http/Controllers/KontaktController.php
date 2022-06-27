<?php

namespace App\Http\Controllers;
use App\Models\Kontakt;
use Illuminate\Http\Request;

class KontaktController extends Controller
{
    public function index()
    {
        $Kontakt = Kontakt::all();
        return view("Kontakt.index", ['Kontakt' => $Kontakt]);
    }
    public function edit($id)
    {
        $Kontakt = Kontakt::find($id);
        return view('Kontakt.edit', ['Kontakt' => $Kontakt]);
    }

    public function update(Request $request, $id)
    {
        $Kontakt = Kontakt::find($id);
        $Kontakt->Adres= $request->input('Adres');
        $Kontakt->NrTelStacjonarny = $request->input('NrTelefonuSt');
        $Kontakt->NrTelKomorkowy = $request->input('NrTelefonuKom');
        $Kontakt->Email = $request->input('Email');
        $Kontakt->save();

        return redirect("/kontakt");
    }
}
