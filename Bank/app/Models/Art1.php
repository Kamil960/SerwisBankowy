<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Art1 extends Model
{
    use HasFactory;

    protected $table = 'art1';
    protected $primaryKey = 'IdArt1';
    const UPDATED_AT = 'EditDateTime';
}
