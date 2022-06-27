<?php

namespace App\Http\Controllers;
use App\Models\Art3;
use Illuminate\Http\Request;

class Art3Controller extends Controller
{
    public function index()
    {
        $Art3 = Art3::all();
        return view("Art3.index", ['Art3' => $Art3]);
    }
    public function edit($id)
    {
        $Art3 = Art3::find($id);
        return view('Art3.edit', ['Art3' => $Art3]);
    }

    public function update(Request $request, $id)
    {
        $Art3 = Art3::find($id);
        $Art3->Tytul = $request->input('Tytul');
        $Art3->Tresc1 = $request->input('Tresc1');
        $Art3->Tresc2 = $request->input('Tresc2');
        $Art3->Tresc3 = $request->input('CrypTytul');
        $Art3->PozycjaG1 = $request->input('PozycjaG1');
        $Art3->PozycjaG2 = $request->input('PozycjaG2');
        $Art3->PozycjaG3 = $request->input('PozycjaG3');
        $Art3->PozycjaG4 = $request->input('PozycjaG4');
        $Art3->Grafika = $request->input('Grafika');
        $Art3->CrypoTytul1 = $request->input('CrypoTytul1');
        $Art3->CrypoTytul2 = $request->input('CrypoTytul2');
        $Art3->CrypoTytul3 = $request->input('CrypoTytul3');
        $Art3->CrypoTytul4 = $request->input('CrypoTytul4');
        $Art3->CrypoIcon1 = $request->input('CrypoIcon1');
        $Art3->CrypoIcon2 = $request->input('CrypoIcon2');
        $Art3->CrypoIcon3 = $request->input('CrypoIcon3');
        $Art3->CrypoIcon4 = $request->input('CrypoIcon4');
        $Art3->save();

        return redirect("/artykul3");
    }
}
