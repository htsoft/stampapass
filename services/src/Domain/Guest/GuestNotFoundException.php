<?php
declare(strict_types=1);

namespace App\Domain\Guest;

use App\Domain\DomainException\DomainRecordNotFoundException;

class GuestNotFoundException extends DomainRecordNotFoundException
{
    public $message = 'The guest you requested does not exist.';
}
