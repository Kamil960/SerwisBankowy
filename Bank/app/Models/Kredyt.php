<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Kredyt extends Model
{
    use HasFactory;

    protected $table = 'Kredyt';
    protected $primaryKey = 'IdKredyt';
    const UPDATED_AT = 'EditDateTime';
    const CREATED_AT = 'CreateDateTime';
}
