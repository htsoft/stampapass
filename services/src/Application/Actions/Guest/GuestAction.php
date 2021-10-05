<?php

declare(strict_types=1);

namespace App\Application\Actions\Guest;

use App\Application\Actions\Action;
use App\Domain\Guest\GuestRepository;
use Psr\Log\LoggerInterface;

abstract class GuestAction extends Action
{
    /**
     * @var GuestRepository
     */
    protected $repository;

    /**
     * @param LoggerInterface $logger
     * @param GuestRepository  $repository
     */
    public function __construct(LoggerInterface $logger, GuestRepository $repository)
    {
        parent::__construct($logger);
        $this->repository = $repository;
    }
}
