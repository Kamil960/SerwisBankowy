<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Art2 extends Model
{
    use HasFactory;

    protected $table = 'art2';
    protected $primaryKey = 'IdArt2';
    const UPDATED_AT = 'EditDateTime';
    
}
