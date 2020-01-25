import React, { Fragment } from 'react';
import RetrospectiveFeedbackAdd from './RetrospectiveFeedbackAdd';

export const RetrospectiveFeedback = ({ feedback, handleAddFeedback }) => {
  return (
    <div style={{ paddingTop: 20 }}>
      <hr />
      <h4>Feedback:</h4>
      <hr />
      {(!feedback || feedback.length) === 0 && (
        <div>
          There is currently no feedback
          <hr />
        </div>
      )}
      {feedback &&
        feedback.length > 0 &&
        feedback.map(f => {
          return (
            <Fragment>
              <div
                key={f.feedbackId}
                style={{
                  backgroundColor: 'rgb(240,240,240)',
                  display: 'inline-block',
                  width: '100%'
                }}
              >
                <div style={{ float: 'left', width: '150px' }}>
                  <div>
                    <u>Name:</u>
                  </div>
                  {f.name}
                </div>
                <div style={{ float: 'left', width: '300px' }}>
                  <div>
                    <u>Body:</u>
                  </div>
                  {f.body}
                </div>
                <div style={{ float: 'left', width: '150px' }}>
                  <div>
                    <u>Type:</u>
                  </div>
                  {f.feedbackType}
                </div>
              </div>
              <hr />
            </Fragment>
          );
        })}
      <RetrospectiveFeedbackAdd handleAddFeedback={handleAddFeedback} />
    </div>
  );
};
