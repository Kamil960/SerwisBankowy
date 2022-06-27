<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Lokata extends Model
{
    use HasFactory;

    protected $table = 'Lokata';
    protected $primaryKey = 'IdLokata';
    const UPDATED_AT = 'EditDateTime';
    const CREATED_AT = 'CreateDateTime';
}
