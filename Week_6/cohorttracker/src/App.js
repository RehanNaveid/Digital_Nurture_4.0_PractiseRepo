import React from 'react';
import CohortDetails from './CohortDetails';
import { CohortsData } from './Cohort';

function App() {
  return (
    <div>
      <h2 style={{ textAlign: 'center' }}>Cohort Dashboard</h2>
      {CohortsData.map((cohort, index) => (
        <CohortDetails key={index} cohort={cohort} />
      ))}
    </div>
  );
}

export default App;
