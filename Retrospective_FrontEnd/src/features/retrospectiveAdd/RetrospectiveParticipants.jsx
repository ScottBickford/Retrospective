import React from 'react';

const RetrospectiveParticipants = ({
  participants,
  setParticipant,
  addParticipant,
  removeParticipant
}) => {
  return (
    <div>
      <div>Participants:</div>
      {participants.filter(p => !p.removed).map(p => {
        return (
          <div key={p.id}>
            <input
              type='text'
              style={{ width: 200 }}
              maxLength='200'
              value={p.name}
              onChange={e => setParticipant(p.id, e.target.value)}
            />
            <a href='/' onClick={(e) => removeParticipant(e, p.id)} style={{ marginTop: 10 }}>
              Remove
            </a>
          </div>
        );
      })}
      <div>
        <a href='/' onClick={addParticipant} style={{ marginTop: 10 }}>
          Add Participant
        </a>
      </div>
    </div>
  );
};

export default RetrospectiveParticipants;
