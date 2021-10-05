<?php

declare(strict_types=1);

namespace App\Application\Actions\Guest;

use App\Domain\Guest\Guest;
use Psr\Http\Message\ResponseInterface as Response;

class UpdateGuestAction extends GuestAction
{
    /**
     * {@inheritdoc}
     */
    protected function action(): Response
    {
        // Ottiene il resto delle informazioni necessarie
        $data = $this->getFormData();
        $this->logger->info("Richiesto l'aggiornamento di un nuovo ospite con badge: " . $data->badge);
        $obj = new Guest(0, $data->cognome, $data->nome, $data->badge, $data->status, '');
        $dato = $this->repository->update($obj);
        return $this->respondWithData($dato);
    }
}
