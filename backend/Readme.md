# Guestbook Backend

This application is a JSON based RESTful implementation of a guest book. Its only dependency is a Postgres database. The application will generate it's own required DB schema on startup.

The application listens on port `5000` once its completed booting.

## Routes

### `GET /api/health`

A health check endpoint that returns `200 OK` when the app is up, healthy and able to connect to the database

### `GET /api/guests`

Returns an array of people that have signed the guest book, e.g.

```
[
  {
    "id": "a811e354-a522-4dd5-b781-02466cf6f194",
    "firstName": "Hilbert",
    "lastName": "Metz",
    "created": "2020-08-24T02:53:24.133Z"
  },
  {
    "id": "823b20b4-cc95-4188-a82b-978070d34216",
    "firstName": "Myrtie",
    "lastName": "Ankunding",
    "created": "2020-08-24T02:53:29.105Z"
  }
]
```

### `POST /api/guests`

Creates an entry in the guest book. It expects a body in the following format:

```
{
  "firstName": "Hilbert",
  "lastName": "Metz"
}
```

## Getting Started

1. `docker-compose up -d postgres` to bring up the database
