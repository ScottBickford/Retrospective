import React, { Fragment, useReducer, useEffect } from 'react';
import {
  retrospectiveItemReducer,
  getRetrospective,
  addFeedback
} from './retrospectiveViewActions';
import { format } from 'date-fns';
import { RetrospectiveFeedback } from './RetrospectiveFeedback';

const initialData = {
  item: null,
  error: null
};

const RetrospectiveViewPage = ({ match, history }) => {
  const [data, dispatch] = useReducer(retrospectiveItemReducer, initialData);

  useEffect(() => {
    getRetrospective(match.params.retrospectiveId, dispatch);
  }, [match.params.retrospectiveId]);

  const handleAddFeedback = feedback => {
    return new Promise((resolve, reject) => {
      addFeedback(match.params.retrospectiveId, feedback)
        .then(response => {
          getRetrospective(match.params.retrospectiveId, dispatch);
          resolve(response);
        })
        .catch(error => {
          reject(new Error(error));
        });
    });
  };

  return (
    <Fragment>
      <h2>View Retrospective</h2>
      {data.item && (
        <Fragment>
          <div style={{ display: 'inline-block' }}>
            <div style={{ float: 'left', width: '150px' }}>
              <div>
                <u>Name:</u>
              </div>
              {data.item.name}
            </div>
            <div style={{ float: 'left', width: '300px' }}>
              <div>
                <u>Summary:</u>
              </div>
              {data.item.summary}
            </div>
            <div style={{ float: 'left', width: '150px' }}>
              <div>
                <u>Date:</u>
              </div>
              {format(new Date(data.item.date), 'd MMMM yyyy')}
            </div>
          </div>
          <div style={{paddingTop:20}}>
            <div>
              <u>Participants:</u>
            </div>
            {data.item.participants.map(p => {
              return <div key={p}>{p}</div>;
            })}
          </div>
          <RetrospectiveFeedback
            feedback={data.item.feedback}
            handleAddFeedback={handleAddFeedback}
          />
          <hr />
          <a href='/'>Go back</a>
        </Fragment>
      )}
    </Fragment>
  );
};

export default RetrospectiveViewPage;
