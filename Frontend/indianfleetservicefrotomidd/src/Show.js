import React, { useState, useEffect } from 'react';
import axios from 'axios';

function Show() {
  const [options1, setOptions1] = useState([]);
  const [options2, setOptions2] = useState([]);
  const [selectedOption1, setSelectedOption1] = useState('');

  useEffect(() => {
    axios.get('https://localhost:7227/api/SegmentMasters/')
      .then(response => {
        setOptions1(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    if (selectedOption1) {
      axios.get(`https://localhost:7227/api/MfgMasters/${selectedOption1}`)
        .then(response => {
          setOptions2(response.data);
        })
        .catch(error => {
          console.log(error);
        });
    }
  }, [selectedOption1]);

  const handleOption1Change = (event) => {
    setSelectedOption1(event.target.value);
  }

  return (
    <div>
      <select value={selectedOption1} onChange={handleOption1Change}>
        <option value="">-- Select Option 1 --</option>
        {options1.map(option => (
          <option key={option.segId} value={option.segId}>{option.segName}</option>
        ))}
      </select>

      {selectedOption1 && (
        <select>
          <option value="">-- Select Option 2 --</option>
          {options2.map(option => (
            <option key={option.mfgid} value={option.mfgId}>{option.label}</option>
          ))}
        </select>
      )}
    </div>
  );
}

export default Show;
