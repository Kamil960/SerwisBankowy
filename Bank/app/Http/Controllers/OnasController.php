<?php

namespace App\Http\Controllers;
use App\Models\Onas;
use Illuminate\Http\Request;

class OnasController extends Controller
{
    public function index()
    {
        $Onas = Onas::all();
        return view("Onas.index", ['Onas' => $Onas]);
    }
    public function edit($id)
    {
        $Onas = Onas::find($id);
        return view('Onas.edit', ['Onas' => $Onas]);
    }

    public function update(Request $request, $id)
    {
        $Onas = Onas::find($id);
        $Onas->Tytul = $request->input('Tytul');
        $Onas->Opis = $request->input('Opis');
        $Onas->Grafika = $request->input('Grafika');
        $Onas->save();

        return redirect("/onas");
    }//
}
