# treasure-api

Ahoy! A simple Express API fer trackin' pirate treasure. Treasure be stored in memory only — restart the ship and the chest empties.

## Install

```powershell
npm install
```

## Run

```powershell
npm start
```

The server listens on `http://localhost:3000` by default (override with the `PORT` environment variable).

## Endpoints

A treasure has this shape:

```json
{
  "id": 1,
  "name": "Doubloon Hoard",
  "value": 5000,
  "location": "Tortuga",
  "dateFound": "1715-07-31"
}
```

### Add treasure — `POST /treasure`

```powershell
curl -X POST http://localhost:3000/treasure `
  -H "Content-Type: application/json" `
  -d '{"name":"Doubloon Hoard","value":5000,"location":"Tortuga","dateFound":"1715-07-31"}'
```

### List all treasure — `GET /treasure`

```powershell
curl http://localhost:3000/treasure
```

### Get treasure by ID — `GET /treasure/:id`

```powershell
curl http://localhost:3000/treasure/1
```

### Delete treasure — `DELETE /treasure/:id`

```powershell
curl -X DELETE http://localhost:3000/treasure/1
```
