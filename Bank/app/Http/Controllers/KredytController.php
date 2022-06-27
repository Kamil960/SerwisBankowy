<?php

namespace App\Http\Controllers;
use App\Models\Kredyt;
use Illuminate\Http\Request;

class KredytController extends Controller
{
    public function index()
    {
        $Kredyt = Kredyt::where("CzyAktywna", "=", true)->get();
        return view("Kredyt.index", ['Kredyt' => $Kredyt]);
    }

    public function edit($id)
    {
        $Kredyt = Kredyt::find($id);
        return view('Kredyt.edit', ['Kredyt' => $Kredyt]);
    }

    public function update(Request $request, $id)
    {
        $Kredyt = Kredyt::find($id);
        $Kredyt->Nazwa = $request->input('Nazwa');
        $Kredyt->Opis= $request->input('Opis');
        $Kredyt->Grafika = $request->input('Grafika');
        $Kredyt->Procent = $request->input('Procent');
        $Kredyt->save();
        return redirect("/kredyt");
    }

    public function add()
    {
        return view('Kredyt.create');
    }

    public function addToDB(Request $request)
    {
        $Kredyt = new Kredyt();
        $Kredyt->IdKredyt = null;
        $Kredyt->Nazwa = $request->input('Nazwa');
        $Kredyt->Opis= $request->input('Opis');
        $Kredyt->Grafika = $request->input('Grafika');
        $Kredyt->Procent = $request->input('Procent');
        $Kredyt->CzyAktywna = true;
        $Kredyt->save();
        return redirect("/kredyt");
    }
    public function preDelete($id)
    {
        $Kredyt = Kredyt::find($id);
        return view('Kredyt.delete', ['Kredyt' => $Kredyt]);
    }
    public function delete($id) 
    {
        $Kredyt = Kredyt::find($id);
        $Kredyt->CzyAktywna = false;
        $Kredyt->save();
        return redirect("/kredyt");
    }
}
