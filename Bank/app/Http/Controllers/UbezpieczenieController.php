<?php

namespace App\Http\Controllers;
use App\Models\Ubezpieczenie;
use Illuminate\Http\Request;

class UbezpieczenieController extends Controller
{
    public function index()
    {
        $Ubezpieczenie = Ubezpieczenie::where("CzyAktywna", "=", true)->get();
        return view("Ubezpieczenie.index", ['Ubezpieczenie' => $Ubezpieczenie]);
    }
    public function edit($id)
    {
        $Ubezpieczenie = Ubezpieczenie::find($id);
        return view('Ubezpieczenie.edit', ['Ubezpieczenie' => $Ubezpieczenie]);
    }

    public function update(Request $request, $id)
    {
        $Ubezpieczenie = Ubezpieczenie::find($id);
        $Ubezpieczenie->Nazwa = $request->input('Nazwa');
        $Ubezpieczenie->Opis= $request->input('Opis');
        $Ubezpieczenie->Grafika = $request->input('Grafika');
        $Ubezpieczenie->save();
        return redirect("/ubezpieczenie");
    }

    public function add()
    {
        return view('Ubezpieczenie.create');
    }

    public function addToDB(Request $request)
    {
        $Ubezpieczenie = new Ubezpieczenie();
        $Ubezpieczenie->IdUbezpieczenie = null;
        $Ubezpieczenie->Nazwa = $request->input('Nazwa');
        $Ubezpieczenie->Opis= $request->input('Opis');
        $Ubezpieczenie->Grafika = $request->input('Grafika');
        $Ubezpieczenie->CzyAktywna = true;
        $Ubezpieczenie->save();
        return redirect("/ubezpieczenie");
    }
    public function preDelete($id)
    {
        $Ubezpieczenie = Ubezpieczenie::find($id);
        return view('Ubezpieczenie.delete', ['Ubezpieczenie' => $Ubezpieczenie]);
    }
    public function delete($id) 
    {
        $Ubezpieczenie = Ubezpieczenie::find($id);
        $Ubezpieczenie->CzyAktywna = false;
        $Ubezpieczenie->save();
        return redirect("/ubezpieczenie");
    }
}
