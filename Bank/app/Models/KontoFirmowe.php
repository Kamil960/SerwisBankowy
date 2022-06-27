<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KontoFirmowe extends Model
{
    use HasFactory;

    protected $table = 'KontoFirmowe';
    protected $primaryKey = 'IdKontoFirmowe';
    const UPDATED_AT = 'EditDateTime';
    const CREATED_AT = 'CreateDateTime';
}
