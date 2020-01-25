import React, { useState, useEffect, useReducer, Fragment } from 'react';
import {
  retrospectiveListReducer,
  getRetrospectives
} from './retrospectiveListActions';
import RetrospectiveList from './RetrospectiveList';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';

const initialData = {
  list: [],
  error: null
};

const RetrospectiveListPage = ({history}) => {
  const [data, dispatch] = useReducer(retrospectiveListReducer, initialData);
  const [filterDate, setFilterDate] = useState(null);

  useEffect(() => {
    getRetrospectives(filterDate, dispatch);
  }, [filterDate]);

  const handleAddRetrospective =() => {
    history.push('/add');
  }

  return (
    <Fragment>
      <h2>Retrospectives</h2>
      {data.error && (
        <div className='error'>An error occured: {data.error.data}</div>
      )}
      {!data.error && (
        <Fragment>
          <div style={{ paddingBottom: 10 }}>
            Filter:{' '}
            <DatePicker
              dateFormat='d MMMM yyyy'
              selected={filterDate}
              onChange={setFilterDate}
              showYearDropdown={true}
              showMonthDropdown={true}
              dropdownMode='select'
            />
            {filterDate !== null && (
              <button onClick={() => setFilterDate(null)}>Clear Filter</button>
            )}
          </div>
          <RetrospectiveList data={data} />          
          <button onClick={handleAddRetrospective} style={{marginTop:10}}>Add Retrospective</button>
        </Fragment>
      )}
    </Fragment>
  );
};

export default RetrospectiveListPage;
