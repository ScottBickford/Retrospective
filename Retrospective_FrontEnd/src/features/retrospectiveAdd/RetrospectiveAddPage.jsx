import React, { Fragment, useState } from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import RetrospectiveParticipants from './RetrospectiveParticipants';
import { createRetrospective } from './retrospectiveAddActions';

const RetrospectiveAddPage = ({ history }) => {
  const [name, setName] = useState('');
  const [summary, setSummary] = useState('');
  const [date, setDate] = useState(null);
  
  const [participants, setParticipants] = useState([
    { id: 0, name: '', removed: false }
  ]);
  const [error, setError] = useState(null);

  const handleSubmit = event => {
    event.preventDefault();
    setError(null);
    createRetrospective({
      name,
      summary,
      date,
      participants: participants
        .filter(p => !p.removed && p.name !== null && p.name !== '')
        .map(p => p.name)
    })
      .then(response => {
        history.push('/');
      })
      .catch(error => {
        setError(error);
      });
  };

  const canSubmit = () => {
    const filerParticipants = participants.filter(
      p => !p.removed && p.name !== null && p.name !== ''
    );
    return (
      name.trim() !== '' &&
      date !== null &&
      date !== '' &&
      filerParticipants.length > 0
    );
  };

  const addParticipant = event => {
    event.preventDefault();
    const newParticipants = [
      ...participants,
      { id: participants.length, name: '', removed: false }
    ];
    setParticipants(newParticipants);
  };

  const setParticipant = (id, value) => {
    const participant = participants.filter(p => p.id === id)[0];
    participant.name = value;
    const newParticipants = [
      ...participants.filter(p => p.id !== id),
      participant
    ].sort((a, b) => a.id - b.id);
    setParticipants(newParticipants);
  };

  const removeParticipant = (event, id) => {
    event.preventDefault();
    const participant = participants.filter(p => p.id === id)[0];
    participant.removed = true;
    const newParticipants = [
      ...participants.filter(p => p.id !== id),
      participant
    ].sort((a, b) => a.id - b.id);
    setParticipants(newParticipants);
  };

  return (
    <Fragment>
      <h2>Add Retrospective</h2>
      {error && <div style={{ color: 'red' }}>{error.message}</div>}
      <form onSubmit={handleSubmit}>
        <div>
          <div>Name:</div>
          <input
            type='text'
            style={{ width: 200 }}
            maxLength='200'
            value={name}
            onChange={e => setName(e.target.value)}
          />
        </div>
        <div>
          <div>Summary:</div>
          <textarea
            style={{ width: 200 }}
            rows={4}
            maxLength='1000'
            value={summary}
            onChange={e => setSummary(e.target.value)}
          />
        </div>
        <div>
          <div>Date:</div>
          <DatePicker
            dateFormat='d MMMM yyyy'
            selected={date}
            onChange={setDate}
            showYearDropdown={true}
            showMonthDropdown={true}
            dropdownMode='select'
          />
        </div>
        <RetrospectiveParticipants
          participants={participants}
          setParticipant={setParticipant}
          addParticipant={addParticipant}
          removeParticipant={removeParticipant}
        />
        <hr />
        <div style={{ paddingTop: 10 }}>
          <button disabled={!canSubmit()}>Submit</button>
          <a href='/'>Cancel</a>
        </div>
      </form>
    </Fragment>
  );
};

export default RetrospectiveAddPage;
