// The captain's chest -- in-memory storage fer the treasure.
const treasures = [];
let nextId = 1;

function add(data) {
  const treasure = {
    id: nextId++,
    name: data.name,
    value: data.value,
    location: data.location,
    dateFound: data.dateFound,
  };
  treasures.push(treasure);
  return treasure;
}

function getById(id) {
  return treasures.find((t) => t.id === id);
}

function remove(id) {
  const index = treasures.findIndex((t) => t.id === id);
  if (index === -1) {
    return false;
  }
  treasures.splice(index, 1);
  return true;
}

function list() {
  return treasures.slice();
}

module.exports = { add, getById, remove, list };
