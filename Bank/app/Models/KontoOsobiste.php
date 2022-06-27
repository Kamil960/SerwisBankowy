<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KontoOsobiste extends Model
{
    use HasFactory;

    protected $table = 'KontoOsobiste';
    protected $primaryKey = 'IdKontoOsobiste';
    const UPDATED_AT = 'EditDateTime';
    const CREATED_AT = 'CreateDateTime';
}
