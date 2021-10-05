<?php
declare(strict_types=1);

namespace App\Domain\Guest;

use JsonSerializable;

class Guest implements JsonSerializable
{
    /**
     * @var int|null
     */
    private $id;

    /**
     * @var string
     */
    private $cognome;

    /**
     * @var string
     */
    private $nome;

    /**
     * @var string
     */
    private $badge;

    /**
     * @var int
     */
    private $status;

    /**
     * @var string
     */
    private $dataarrivo;


    /**
     * @param int|null  $id
     * @param string    $cognome
     * @param string    $nome
     * @param string    $badge
     * @param int       $status
     * @param string    $dataarrivo  
     */
    public function __construct(?int $id, string $cognome, string $nome, string $badge, int $status, string $dataarrivo)
    {
        $this->id = $id;
        $this->cognome = ucfirst($cognome);
        $this->nome = ucfirst($nome);
        $this->badge = $badge;
        $this->status = $status;
        $this->dataarrivo = $dataarrivo;
    }

    /**
     * @return int|null
     */
    public function getId(): ?int
    {
        return $this->id;
    }

    /**
     * @return string
     */
    public function getCognome(): string
    {
        return $this->cognome;
    }

    /**
     * @return string
     */
    public function getNome(): string
    {
        return $this->nome;
    }

    /**
     * @return string
     */
    public function getBadge(): string
    {
        return $this->badge;
    }

    /**
     * @return int
     */
    public function getStatus(): int
    {
        return $this->status;
    }

    /** 
     * @return string
     */
    public function getDataarrivo(): string
    {
        return $this->dataarrivo;
    }

    /**
     * @return array
     */
    public function jsonSerialize()
    {
        return [
            'id' => $this->id,
            'cognome' => $this->cognome,
            'nome' => $this->nome,
            'badge' => $this->badge,
            'status' => $this->status,
            'dataarrivo' => $this->dataarrivo,
        ];
    }
}
