import React from "react";
import ListofPlayers from "./components/ListofPlayers";
import Scorebelow70 from "./components/Scorebelow70";
import OddPlayers from "./components/OddPlayers";
import EvenPlayers from "./components/EvenPlayers";
import ListofIndianPlayers from "./components/ListofIndianPlayers";

export default function App() {
  var flag = true;

  const players = [
    { name: "Virat", score: 85 },
    { name: "Rohit", score: 92 },
    { name: "Rahul", score: 66 },
    { name: "Shreyas", score: 45 },
    { name: "Pant", score: 77 },
    { name: "Jadeja", score: 55 },
    { name: "Hardik", score: 88 },
    { name: "Bumrah", score: 40 },
    { name: "Shami", score: 69 },
    { name: "Siraj", score: 74 },
    { name: "Ashwin", score: 82 },
  ];

  const IndianTeam = [
    "Dhoni 1",
    "Jaddu 2",
    "Virat 3",
    "Rohit 4",
    "Bumrah 5",
    "Hardik 6",
  ];

  const T20Players = ["First Player", "Second Player", "Third Player"];
  const RanjiTrophyPlayers = ["Fourth Player", "Fifth Player", "Sixth Player"];
  const IndianPlayers = [...T20Players, ...RanjiTrophyPlayers];

  if (flag === true) {
    return (
      <div>
        <h1>List of Players</h1>
        <ListofPlayers players={players} />
        <hr />
        <h1>List of Players having Scores Less than 70</h1>
        <Scorebelow70 players={players} />
      </div>
    );
  } else {
    return (
      <div>
        <div>
          <h1>Indian Team</h1>
          <h1>Odd Players</h1>
          <OddPlayers IndianTeam={IndianTeam} />
          <hr />
          <h1>Even Players</h1>
          <EvenPlayers IndianTeam={IndianTeam} />
        </div>
        <hr />
        <div>
          <h1>List of Indian Players Merged:</h1>
          <ListofIndianPlayers IndianPlayers={IndianPlayers} />
        </div>
      </div>
    );
  }
}
