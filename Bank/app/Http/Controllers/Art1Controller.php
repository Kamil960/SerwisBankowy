<?php

namespace App\Http\Controllers;
use App\Models\Art1;
use Illuminate\Http\Request;

class Art1Controller extends Controller
{
    public function index()
    {
        $Art = Art1::all();
        return view("Art1.index", ['Art1' => $Art]);
    }
    public function edit($id)
    {
        $Art1 = Art1::find($id);
        return view('Art1.edit', ['Art1' => $Art1]);
    }

    public function update(Request $request, $id)
    {
        $Art1 = Art1::find($id);
        $Art1->Tytul = $request->input('Tytul');
        $Art1->Nazwa1 = $request->input('Nazwa1');
        $Art1->Nazwa2 = $request->input('Nazwa2');
        $Art1->Nazwa3 = $request->input('Nazwa3');
        $Art1->Grafika1 = $request->input('Grafika1');
        $Art1->Grafika2 = $request->input('Grafika2');
        $Art1->Grafika3 = $request->input('Grafika3');
        $Art1->Podsumowanie = $request->input('Podsumowanie');
        $Art1->save();

        return redirect("/artykul1");
    }
}

