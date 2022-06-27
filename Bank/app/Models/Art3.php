<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Art3 extends Model
{
    use HasFactory;

    protected $table = 'art3';
    protected $primaryKey = 'IdArt3';
    const UPDATED_AT = 'EditDateTime';
}
