import React from 'react';
import { CalculateScore } from './components/CalculateScore';

function App() {
  return (
    <div className="App">
      <CalculateScore Name="Rehan" School="Achyuta Public School" total={450} goal={5} />
    </div>
  );
}

export default App;
