import React, { useState } from "react";

export default function Counter() {
  const [count, setCount] = useState(0);

  // Step 1.a: Increment function
  const increment = () => {
    setCount(count + 1);
    sayHello(); // Step 1.b
  };

  // Step 1.b: Say hello static message
  const sayHello = () => {
    console.log("Hello! This is a static message.");
    alert("Hello! This is a static message.");
  };

  // Decrement function
  const decrement = () => {
    setCount(count - 1);
  };

  return (
    <div>
      <p>{count}</p>
      <button onClick={increment}>Increment</button>
      <br />
      <button onClick={decrement}>Decrement</button>
    </div>
  );
}
