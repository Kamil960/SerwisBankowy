<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Kontakt extends Model
{
    use HasFactory;

    protected $table = 'Kontakt';
    protected $primaryKey = 'IdKontakt';
    const UPDATED_AT = 'EditDateTime';
}
