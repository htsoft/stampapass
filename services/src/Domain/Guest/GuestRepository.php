<?php
declare(strict_types=1);

namespace App\Domain\Guest;

interface GuestRepository
{
    /**
     * @return Guest[]
     */
    public function getAll(): array;

    /** 
     * @param string $badge
     * @return Guest
     * @throws GuestNotFoundException
     */
    public function get(string $badge): Guest;

    /** 
     * @param Guest $guest
     * @return Guest
     * @throws GuestNotFoundException
     */
    public function insert(Guest $guest): Guest;

    /** 
     * @param Guest $guest
     * @return Guest
     * @throws GuestNotFoundException
     */
    public function update(Guest $guest): Guest;

    /** 
     * @param string $badge
     * @return Guest
     * @throws GuestNotFoundException
     */
    public function checkin(string $badge): Guest;

}
