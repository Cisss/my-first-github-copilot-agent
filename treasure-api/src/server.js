// Hoist the colors -- this be the main deck of the treasure API.
const express = require('express');
const treasureRoutes = require('./routes/treasure');

const app = express();

app.use(express.json());

app.get('/', (req, res) => {
  res.status(200).type('text/plain').send('Ahoy! Treasure API afloat.');
});

app.use('/treasure', treasureRoutes);

// No such port on the chart, matey.
app.use((req, res, next) => {
  res.status(404).json({ error: 'Route not found' });
});

// Error middleware -- catches bad JSON and any other squalls.
// eslint-disable-next-line no-unused-vars
app.use((err, req, res, next) => {
  if (err && err.type === 'entity.parse.failed') {
    return res.status(400).json({ error: 'Invalid JSON body' });
  }
  return res.status(500).json({ error: 'Internal server error' });
});

const port = process.env.PORT || 3000;

if (require.main === module) {
  app.listen(port, () => {
    console.log(`Treasure API listening on port ${port}`);
  });
}

module.exports = app;
