<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Onas extends Model
{
    use HasFactory;

    protected $table = 'Onas';
    protected $primaryKey = 'IdOnas';
    const UPDATED_AT = 'EditDateTime';
}
