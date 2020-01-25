import React from 'react';
import renderer from 'react-test-renderer';
import RetrospectiveListPage from './RetrospectiveListPage';

describe('RetrospectiveListPage', () => {
  test('snapshot renders', () => {    
    const component = renderer.create(<RetrospectiveListPage />);
    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});