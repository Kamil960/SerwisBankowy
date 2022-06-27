<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Ubezpieczenie extends Model
{
    use HasFactory;

    protected $table = 'Ubezpieczenie';
    protected $primaryKey = 'IdUbezpieczenie';
    const UPDATED_AT = 'EditDateTime';
    const CREATED_AT = 'CreateDateTime';
}
