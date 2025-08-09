import React from 'react';

// Using array destructuring in the function parameters
function OddPlayers({ IndianTeam: [first, , third, , fifth] }) {
  return (
    <div>
      <li>First : {first}</li>
      <li>Third : {third}</li>
      <li>Fifth : {fifth}</li>
    </div>
  );
}

export default OddPlayers;