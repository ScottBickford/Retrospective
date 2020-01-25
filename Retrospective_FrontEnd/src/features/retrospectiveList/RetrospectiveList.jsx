import React, { Fragment } from 'react';
import { format } from 'date-fns';

const RetrospectiveList = ({ data }) => {
  return (
    <Fragment>
      {data.list.length === 0 && <div>There are no items</div>}
      {data.list.length > 0 && (
        <table border={1} cellSpacing={0} cellPadding={4}>
          <thead>
            <tr>
              <td>Name</td>
              <td>Summary</td>
              <td>Date</td>
              <td>Participants</td>
              <td></td>
            </tr>
          </thead>
          <tbody>
            {data.list.map(item => (
              <tr key={item.name}>
                <td>{item.name}</td>
                <td>{item.summary}</td>
                <td>{format(new Date(item.date), 'd MMMM yyyy')}</td>
                <td>
                  {item.participants &&
                    item.participants.map(participant => {
                      return <div key={participant}>{participant}</div>;
                    })}
                </td>
                <td><a href={`/view/${item.retrospectiveId}`}>View</a></td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </Fragment>
  );
};

export default RetrospectiveList;
