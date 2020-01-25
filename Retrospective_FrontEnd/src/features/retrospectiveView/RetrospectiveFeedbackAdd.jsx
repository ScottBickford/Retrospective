import React, { Fragment, useState } from 'react';

const RetrospectiveFeedbackAdd = ({ handleAddFeedback }) => {
  const [name, setName] = useState('');
  const [body, setBody] = useState('');
  const [feedbackType, setFeedbackType] = useState('');
  const [error, setError] = useState(null);

  const handleSubmit = event => {
    event.preventDefault();
    setError(null);
    handleAddFeedback({ name, body, feedbackType })
      .then(response => {
        clearFields();
      })
      .catch(error => {
        setError(error);
      });
  };

  const canSubmit = () => {
    return name.trim() !== '' && body.trim() !== '' && feedbackType !== '';
  };

  const clearFields = () => {
    setName('');
    setBody('');
    setFeedbackType('');
  }

  const feedbackTypeOptions = () => {
    const options = ['', 'Positive', 'Negative', 'Idea', 'Praise'];
    return options.map(o => (
      <option key={o} value={o}>
        {o}
      </option>
    ));
  };

  return (
    <Fragment>
      <h4>Add feeback</h4>
      {error && <div style={{ color: 'red' }}>{error.message}</div>}
      <form onSubmit={handleSubmit}>
        <div>
          <div>Name of person:</div>
          <input
            type='text'
            style={{ width: 200 }}
            maxLength='200'
            value={name}
            onChange={e => setName(e.target.value)}
          />
        </div>
        <div>
          <div>Body:</div>
          <input
            type='text'
            style={{ width: 200 }}
            maxLength='1000'
            value={body}
            onChange={e => setBody(e.target.value)}
          />
        </div>
        <div>
          <div>Feedback type:</div>
          <select
            type='text'
            style={{ width: 200 }}
            maxLength='1000'
            value={feedbackType}
            onChange={e => setFeedbackType(e.target.value)}
          >
            {feedbackTypeOptions()}
          </select>
        </div>
        <button style={{marginTop:10}} disabled={!canSubmit()}>Submit</button>
      </form>
    </Fragment>
  );
};

export default RetrospectiveFeedbackAdd;
