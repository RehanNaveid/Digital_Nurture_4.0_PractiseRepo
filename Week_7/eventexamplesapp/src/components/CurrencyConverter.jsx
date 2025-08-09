import React, { useState } from "react";

export default function CurrencyConverter() {
  const [amount, setAmount] = useState("");
  const [currency, setCurrency] = useState("");

  // Step 4: Convert INR → Euro
  const handleSubmit = (event) => {
    event.preventDefault();
    const euroRate = 0.011; // Example: 1 INR = 0.011 Euro
    const converted = (parseFloat(amount) * euroRate).toFixed(2);

    setCurrency(`€${converted}`);
    alert(`Converting to Euro Amount is ${converted}`);
  };

  return (
    <div style={{ marginTop: "20px" }}>
      <h1 style={{ color: "green" }}>Currency Convertor!!!</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Amount:
          <input
            type="number"
            value={amount}
            onChange={(e) => setAmount(e.target.value)}
            required
          />
        </label>
        <br />
        <label>
          Currency:
          <textarea value={currency} readOnly />
        </label>
        <br />
        <button type="submit">Convert</button>
      </form>
    </div>
  );
}
