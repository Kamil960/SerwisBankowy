<?php

namespace App\Http\Controllers;
use App\Models\KontoOsobiste;
use Illuminate\Http\Request;

class KontoOsobisteController extends Controller
{
    public function index()
    {
        $KontoOsobiste = KontoOsobiste::where("CzyAktywna", "=", true)->get();
        return view("KontoOsobiste.index", ['KontoOsobiste' => $KontoOsobiste]);
    }
    public function edit($id)
    {
        $KontoOsobiste = KontoOsobiste::find($id);
        return view('KontoOsobiste.edit', ['KontoOsobiste' => $KontoOsobiste]);
    }

    public function update(Request $request, $id)
    {
        $KontoOsobiste = KontoOsobiste::find($id);
        $KontoOsobiste->Nazwa = $request->input('Nazwa');
        $KontoOsobiste->Opis= $request->input('Opis');
        $KontoOsobiste->Grafika = $request->input('Grafika');
        $KontoOsobiste->save();
        return redirect("/kontoOsobiste");
    }

    public function add()
    {
        return view('KontoOsobiste.create');
    }

    public function addToDB(Request $request)
    {
        $KontoOsobiste = new KontoOsobiste();
        $KontoOsobiste->IdKontoOsobiste = null;
        $KontoOsobiste->Nazwa = $request->input('Nazwa');
        $KontoOsobiste->Opis= $request->input('Opis');
        $KontoOsobiste->Grafika = $request->input('Grafika');
        $KontoOsobiste->CzyAktywna = true;
        $KontoOsobiste->save();
        return redirect("/kontoOsobiste");
    }
    public function preDelete($id)
    {
        $KontoOsobiste = KontoOsobiste::find($id);
        return view('KontoOsobiste.delete', ['KontoOsobiste' => $KontoOsobiste]);
    }
    public function delete($id) 
    {
        $KontoOsobiste = KontoOsobiste::find($id);
        $KontoOsobiste->CzyAktywna = false;
        $KontoOsobiste->save();
        return redirect("/kontoOsobiste");
    }
}
