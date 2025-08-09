import React from "react";

function GuestGreeting() {
  return (
    <div>
      <h1>Welcome Guest! 👋</h1>
      <p>Here are the available flights:</p>
      <ul>
        <li>Flight A - New Delhi to Mumbai</li>
        <li>Flight B - Chennai to Bangalore</li>
        <li>Flight C - Kolkata to Goa</li>
      </ul>
      <p>Login to book your tickets.</p>
    </div>
  );
}

export default GuestGreeting;
