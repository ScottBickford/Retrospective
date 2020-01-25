import React from 'react';
import renderer from 'react-test-renderer';
import RetrospectiveFeedbackAdd from './RetrospectiveFeedbackAdd';

describe('RetrospectiveFeedbackAdd', () => {
  test('snapshot renders', () => {    
    const component = renderer.create(<RetrospectiveFeedbackAdd />);
    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});