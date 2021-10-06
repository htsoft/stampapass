<?php

namespace App\Infrastructure\Persistence\Guest;

use App\Domain\Guest\Guest;
use App\Domain\Guest\GuestNotFoundException;
use App\Domain\Guest\GuestRepository;
use PDO;

class DBGuestRepository implements GuestRepository
{
    /**
     * @var PDO
     */
    private $connection;

    /**
     * @param PDO   $connection
     */
    public function __construct(PDO $connection)
    {
        $this->connection = $connection;
    }

    /**
     * {@inheritdoc}
     */
    public function getAll(): array
    {
        $retData = array();
        $query = 'SELECT id, cognome, nome, badge, status, dataarrivo FROM guests';
        $stmt = $this->connection->prepare($query);
        $stmt->execute();
        if ($stmt->rowCount() > 0) {
            while ($row = $stmt->fetch()) {
                $rec = new Guest($row['id'], $row['cognome'], $row['nome'], $row['badge'], $row['status'], $row['dataarrivo']);
                $retData[] = $rec;
            }
        }
        return $retData;
    }

    /**
     * {@inheritdoc}
     */
    public function get(string $badge): Guest
    {
        $retData = null;
        $query = 'SELECT id, cognome, nome, badge, status, dataarrivo FROM guests WHERE badge=:badge';
        $stmt = $this->connection->prepare($query);
        $stmt->execute(array(":badge" => $badge));
        if ($stmt->rowCount() > 0) {
            $row = $stmt->fetch();
            $retData = new Guest($row['id'], $row['cognome'], $row['nome'], $row['badge'], $row['status'], $row['dataarrivo']);
        } else {
            throw new GuestNotFoundException();
        }
        return $retData;
    }

    /**
     * {@inheritdoc}
     */
    public function insert(Guest $guest): Guest
    {
        $result = null;
        $query = "INSERT INTO guests(cognome,nome,badge,status) VALUES(:cognome,:nome,:badge,:status)";
        $stmt = $this->connection->prepare($query);
        $params = array(":cognome" => $guest->getCognome(), ":nome" => $guest->getNome(), ":badge" => $guest->getBadge(), ":status" => $guest->getStatus());
        if ($stmt->execute($params)) {
            $id = $this->connection->lastInsertId();
            $result = $this->get($guest->getBadge());
        } else {
            throw new GuestNotFoundException();
        }
        return $result;
    }

    /**
     * {@inheritdoc}
     */
    public function update(Guest $guest): Guest
    {
        $result = null;
        $query = "UPDATE guests SET cognome=:cognome, nome=:nome, badge=:badge, status=:status WHERE badge=:badge";
        $stmt = $this->connection->prepare($query);
        $params = array(":cognome" => $guest->getCognome(), ":nome" => $guest->getNome(), ":badge" => $guest->getBadge(), ":status" => $guest->getStatus(), ":badge" => $guest->getBadge());
        if ($stmt->execute($params)) {
            $result = $this->get($guest->getBadge());
        } else {
            throw new GuestNotFoundException();
        }
        return $result;
    }

    /**
     * {@inheritdoc}
     */
    public function checkin(string $badge): Guest
    {
        $result = null;
        $query = "UPDATE guests SET status=1 WHERE badge=:badge";
        $stmt = $this->connection->prepare($query);
        $params = array(":badge" => $badge);
        if ($stmt->execute($params)) {
            $result = $this->get($badge);
        } else {
            throw new GuestNotFoundException();
        }
        return $result;
    }
}
