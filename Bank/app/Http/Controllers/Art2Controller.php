<?php

namespace App\Http\Controllers;

use App\Models\Art2;
use Illuminate\Http\Request;

class Art2Controller extends Controller
{
    public function index()
    {
        $Art2 = Art2::all();
        return view("Art2.index", ['Art2' => $Art2]);
    }
    public function edit($id)
    {
        $Art2 = Art2::find($id);
        return view('Art2.edit', ['Art2' => $Art2]);
    }

    public function update(Request $request, $id)
    {
        $Art2 = Art2::find($id);
        $Art2->Tytul = $request->input('Tytul');
        $Art2->Tresc1 = $request->input('Tresc1');
        $Art2->Tresc2 = $request->input('Tresc2');
        $Art2->Grafika = $request->input('Grafika');
        $Art2->save();

        return redirect("/artykul2");
    }
}
