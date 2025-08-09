import React from 'react';

// Using array destructuring for even-indexed players
function EvenPlayers({ IndianTeam: [, second, , fourth, , sixth] }) {
  return (
    <div>
      <li>Second: {second}</li>
      <li>Fourth: {fourth}</li>
      <li>Sixth: {sixth}</li>
    </div>
  );
}

export default EvenPlayers;