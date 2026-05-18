// Treasure routes -- where the gold gets logged and looted.
const express = require('express');
const store = require('../store/treasureStore');

const router = express.Router();

const MAX_STRING_LENGTH = 200;

function validateTreasureBody(body) {
  if (!body || typeof body !== 'object' || Array.isArray(body)) {
    return 'Request body must be a JSON object';
  }

  const { name, value, location, dateFound } = body;

  if (name === undefined || value === undefined || location === undefined || dateFound === undefined) {
    return 'Fields name, value, location, and dateFound are all required';
  }

  if (typeof name !== 'string') {
    return 'Field name must be a string';
  }
  const trimmedName = name.trim();
  if (trimmedName.length === 0) {
    return 'Field name must not be empty';
  }
  if (trimmedName.length > MAX_STRING_LENGTH) {
    return `Field name must be ${MAX_STRING_LENGTH} characters or fewer`;
  }

  if (typeof value !== 'number' || !Number.isFinite(value)) {
    return 'Field value must be a finite number';
  }
  if (value < 0) {
    return 'Field value must be greater than or equal to 0';
  }

  if (typeof location !== 'string') {
    return 'Field location must be a string';
  }
  const trimmedLocation = location.trim();
  if (trimmedLocation.length === 0) {
    return 'Field location must not be empty';
  }
  if (trimmedLocation.length > MAX_STRING_LENGTH) {
    return `Field location must be ${MAX_STRING_LENGTH} characters or fewer`;
  }

  if (typeof dateFound !== 'string') {
    return 'Field dateFound must be a string';
  }
  const parsedDate = new Date(dateFound);
  if (Number.isNaN(parsedDate.getTime())) {
    return 'Field dateFound must be a valid date string';
  }

  return {
    name: trimmedName,
    value,
    location: trimmedLocation,
    dateFound,
  };
}

function parseId(rawId) {
  const coerced = Number(rawId);
  if (!Number.isInteger(coerced) || coerced <= 0) {
    return null;
  }
  return coerced;
}

router.post('/', (req, res) => {
  const result = validateTreasureBody(req.body);
  if (typeof result === 'string') {
    return res.status(400).json({ error: result });
  }
  const created = store.add(result);
  return res.status(201).json(created);
});

router.get('/', (req, res) => {
  return res.status(200).json(store.list());
});

router.get('/:id', (req, res) => {
  const id = parseId(req.params.id);
  if (id === null) {
    return res.status(400).json({ error: 'Field id must be a positive integer' });
  }
  const found = store.getById(id);
  if (!found) {
    return res.status(404).json({ error: 'Treasure not found' });
  }
  return res.status(200).json(found);
});

router.delete('/:id', (req, res) => {
  const id = parseId(req.params.id);
  if (id === null) {
    return res.status(400).json({ error: 'Field id must be a positive integer' });
  }
  const removed = store.remove(id);
  if (!removed) {
    return res.status(404).json({ error: 'Treasure not found' });
  }
  return res.status(204).send();
});

module.exports = router;
