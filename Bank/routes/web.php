<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Home;
use App\Http\Controllers\Art1Controller;
use App\Http\Controllers\Art2Controller;
use App\Http\Controllers\Art3Controller;
use App\Http\Controllers\KontaktController;
use App\Http\Controllers\OnasController;
use App\Http\Controllers\KontoOsobisteController;
use App\Http\Controllers\KontoFirmoweController;
use App\Http\Controllers\KredytController;
use App\Http\Controllers\LokataController;
use App\Http\Controllers\UbezpieczenieController;


/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|


Route::get('/', function () {
    return view('welcome');
});
*/
Route::get('/', Home::class);
Route::get('/artykul1', [Art1Controller::class, 'index']);
Route::get('/artykul1/edycja/{id}', [Art1Controller::class, 'edit']);
Route::post('/artykul1/aktualizacja/{id}', [Art1Controller::class, 'update']);

Route::get('/artykul2', [Art2Controller::class, 'index']);
Route::get('/artykul2/edycja/{id}', [Art2Controller::class, 'edit']);
Route::post('/artykul2/aktualizacja/{id}', [Art2Controller::class, 'update']);

Route::get('/artykul3', [Art3Controller::class, 'index']);
Route::get('/artykul3/edycja/{id}', [Art3Controller::class, 'edit']);
Route::post('/artykul3/aktualizacja/{id}', [Art3Controller::class, 'update']);

Route::get('/onas', [OnasController::class, 'index']);
Route::get('/onas/edycja/{id}', [OnasController::class, 'edit']);
Route::post('/onas/aktualizacja/{id}', [OnasController::class, 'update']);

Route::get('/kontakt', [KontaktController::class, 'index']);
Route::get('/kontakt/edycja/{id}', [KontaktController::class, 'edit']);
Route::post('/kontakt/aktualizacja/{id}', [KontaktController::class, 'update']);

Route::get('/kontoOsobiste', [KontoOsobisteController::class, 'index']);
Route::get('/kontoOsobiste/edycja/{id}', [KontoOsobisteController::class, 'edit']);
Route::post('/kontoOsobiste/aktualizacja/{id}', [KontoOsobisteController::class, 'update']);
Route::get('/kontoOsobiste/dodawanie', [KontoOsobisteController::class, 'add']);
Route::post('/kontoOsobiste/dodaj', [KontoOsobisteController::class, 'addToDB']);
Route::get('/kontoOsobiste/usuwanie/{id}', [KontoOsobisteController::class, 'preDelete']);
Route::get('/kontoOsobiste/usun/{id}', [KontoOsobisteController::class, 'delete']);

Route::get('/kredyt', [KredytController::class, 'index']);
Route::get('/kredyt/edycja/{id}', [KredytController::class, 'edit']);
Route::post('/kredyt/aktualizacja/{id}', [KredytController::class, 'update']);
Route::get('/kredyt/dodawanie', [KredytController::class, 'add']);
Route::post('/kredyt/dodaj', [KredytController::class, 'addToDB']);
Route::get('/kredyt/usuwanie/{id}', [KredytController::class, 'preDelete']);
Route::get('/kredyt/usun/{id}', [KredytController::class, 'delete'])
;
Route::get('/lokata', [LokataController::class, 'index']);
Route::get('/lokata/edycja/{id}', [LokataController::class, 'edit']);
Route::post('/lokata/aktualizacja/{id}', [LokataController::class, 'update']);
Route::get('/lokata/dodawanie', [LokataController::class, 'add']);
Route::post('/lokata/dodaj', [LokataController::class, 'addToDB']);
Route::get('/lokata/usuwanie/{id}', [LokataController::class, 'preDelete']);
Route::get('/lokata/usun/{id}', [LokataController::class, 'delete']);

Route::get('/ubezpieczenie', [UbezpieczenieController::class, 'index']);
Route::get('/ubezpieczenie/edycja/{id}', [UbezpieczenieController::class, 'edit']);
Route::post('/ubezpieczenie/aktualizacja/{id}', [UbezpieczenieController::class, 'update']);
Route::get('/ubezpieczenie/dodawanie', [UbezpieczenieController::class, 'add']);
Route::post('/ubezpieczenie/dodaj', [UbezpieczenieController::class, 'addToDB']);
Route::get('/ubezpieczenie/usuwanie/{id}', [UbezpieczenieController::class, 'preDelete']);
Route::get('/ubezpieczenie/usun/{id}', [UbezpieczenieController::class, 'delete']);
