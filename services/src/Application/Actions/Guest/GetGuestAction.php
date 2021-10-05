<?php

declare(strict_types=1);

namespace App\Application\Actions\Guest;

use Psr\Http\Message\ResponseInterface as Response;

class GetGuestAction extends GuestAction
{
    /**
     * {@inheritdoc}
     */
    protected function action(): Response
    {
        $badge = $this->resolveArg('badge');
        $this->logger->info("Richiede l'ospite legato al badge: " . $badge);
        $guest = $this->repository->get($badge);
        return $this->respondWithData($guest);
    }
}
