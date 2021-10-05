<?php

declare(strict_types=1);

namespace App\Application\Actions\Guest;

use Psr\Http\Message\ResponseInterface as Response;

class ListGuestAction extends GuestAction
{
    /**
     * {@inheritdoc}
     */
    protected function action(): Response
    {
        $this->logger->info("Richiesta la lista degli ospiti");
        $guests = $this->repository->getAll();
        return $this->respondWithData($guests);
    }
}
