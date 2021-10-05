<?php
declare(strict_types=1);

use App\Application\Actions\User\ListUsersAction;
use App\Application\Actions\User\ViewUserAction;

use App\Application\Actions\Guest\ListGuestAction;
use App\Application\Actions\Guest\CheckinGuestAction;
use App\Application\Actions\Guest\GetGuestAction;
use App\Application\Actions\Guest\InsertGuestAction;
use App\Application\Actions\Guest\UpdateGuestAction;

use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Slim\App;
use Slim\Interfaces\RouteCollectorProxyInterface as Group;

return function (App $app) {
    $app->options('/{routes:.*}', function (Request $request, Response $response) {
        // CORS Pre-Flight OPTIONS Request Handler
        return $response;
    });

    $app->get('/', function (Request $request, Response $response) {
        $response->getBody()->write('Hello world!');
        return $response;
    });

    $app->group('/users', function (Group $group) {
        $group->get('', ListUsersAction::class);
        $group->get('/{id}', ViewUserAction::class);
    });

    $app->group('/guests', function (Group $group) {
        $group->get('/list', ListGuestAction::class);
        $group->get('/checkin/{badge}', CheckinGuestAction::class);
        $group->get('/get/{badge}', GetGuestAction::class);
        $group->post('/', InsertGuestAction::class);
        $group->put('/', UpdateGuestAction::class);
    });
};
