<?php

namespace App\Http\Controllers;
use App\Models\Lokata;
use Illuminate\Http\Request;

class LokataController extends Controller
{
    public function index()
    {
        $Lokata = Lokata::where("CzyAktywna", "=", true)->get();
        return view("Lokata.index", ['Lokata' => $Lokata]);
    }

    public function edit($id)
    {
        $Lokata = Lokata::find($id);
        return view('Lokata.edit', ['Lokata' => $Lokata]);
    }

    public function update(Request $request, $id)
    {
        $Lokata = Lokata::find($id);
        $Lokata->Nazwa = $request->input('Nazwa');
        $Lokata->Opis= $request->input('Opis');
        $Lokata->Grafika = $request->input('Grafika');
        $Lokata->Oprocentowanie = $request->input('Procent');
        $Lokata->save();
        return redirect("/lokata");
    }

    public function add()
    {
        return view('Lokata.create');
    }

    public function addToDB(Request $request)
    {
        $Lokata = new Lokata();
        $Lokata->IdLokata = null;
        $Lokata->Nazwa = $request->input('Nazwa');
        $Lokata->Opis= $request->input('Opis');
        $Lokata->Grafika = $request->input('Grafika');
        $Lokata->Oprocentowanie = $request->input('Procent');
        $Lokata->CzyAktywna = true;
        $Lokata->save();
        return redirect("/lokata");
    }
    public function preDelete($id)
    {
        $Lokata = Lokata::find($id);
        return view('Lokata.delete', ['Lokata' => $Lokata]);
    }
    public function delete($id) 
    {
        $Lokata = Lokata::find($id);
        $Lokata->CzyAktywna = false;
        $Lokata->save();
        return redirect("/lokata");
    }
}
