import React, { Fragment } from 'react';
import './App.css';
import { Route } from 'react-router-dom';
import RetrospectiveListPage from './features/retrospectiveList/RetrospectiveListPage';
import RetrospectiveAddPage from './features/retrospectiveAdd/RetrospectiveAddPage';
import RetrospectiveViewPage from './features/retrospectiveView/RetrospectiveViewPage';

function App() {
  return (
    <div style={{paddingLeft:10}}>
      <Route exact path='/' component={RetrospectiveListPage} />
      <Route
        path='/(.+)'
        render={() => (
          <Fragment>
            <Route exact path='/add' component={RetrospectiveAddPage} />
            <Route exact
              path='/view/:retrospectiveId'
              component={RetrospectiveViewPage}
            />
          </Fragment>
        )}
      />
    </div>
  );
}

export default App;
