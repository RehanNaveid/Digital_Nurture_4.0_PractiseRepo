import React from "react";
import Counter from "./components/Counter";
import CurrencyConverter from "./components/CurrencyConverter";

export default function App() {
  // Function for Step 2
  const sayWelcome = (message) => {
    alert(message);
  };

  // Function for Step 3
  const handleOnPress = () => {
    alert("I was clicked");
  };

  return (
    <div style={{ margin: "20px" }}>
      {/* Step 1 */}
      <Counter />

      {/* Step 2 */}
      <button onClick={() => sayWelcome("Welcome")}>Say welcome</button>
      <br />

      {/* Step 3 */}
      <button onClick={handleOnPress}>Click on me</button>

      {/* Step 4 */}
      <CurrencyConverter />
    </div>
  );
}
