import React from 'react';
import renderer from 'react-test-renderer';
import RetrospectiveAddPage from './RetrospectiveAddPage';

describe('RetrospectiveAddPage', () => {
  test('snapshot renders', () => {    
    const component = renderer.create(<RetrospectiveAddPage />);
    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});