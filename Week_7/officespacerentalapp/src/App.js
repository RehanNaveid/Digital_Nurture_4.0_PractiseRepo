import React from "react";
import "./App.css";

function App() {
  const element = "Office Space";

  // Office space list with images
  const officeList = [
    { Name: "DBS", Rent: 50000, Address: "Chennai", Image: "/office1.jpeg" },
    { Name: "Regus", Rent: 75000, Address: "Bangalore", Image: "office2.jpeg" },
    { Name: "WeWork", Rent: 60000, Address: "Mumbai", Image: "/office1.jpeg" },
    { Name: "SmartWorks", Rent: 45000, Address: "Delhi", Image: "/office2.jpeg" }
  ];

  return (
    <div className="App">
      <h1>{element}, at Affordable Range</h1>

      {officeList.map((ItemName, index) => {
        // Implement CSS logic exactly like screenshot
        let colors = [];
        if (ItemName.Rent <= 60000) {
          colors.push("textRed");
        } else {
          colors.push("textGreen");
        }

        return (
          <div key={index} className="office-card">
            <img
              src={ItemName.Image}
              width="25%"
              height="25%"
              alt={ItemName.Name}
            />
            <h1>Name: {ItemName.Name}</h1>
            <h3 className={colors.join(" ")}>Rent: Rs. {ItemName.Rent}</h3>
            <h3>Address: {ItemName.Address}</h3>
          </div>
        );
      })}
    </div>
  );
}

export default App;
