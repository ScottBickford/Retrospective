import React from 'react';
import { render } from '@testing-library/react';
import renderer from 'react-test-renderer';
import RetrospectiveParticipants from "./RetrospectiveParticipants";

const participants = [{id: 1, name: 'Person 1', removed: false}];
describe('RetrospectiveParticipants', () => {
  test('snapshot renders', () => {    
    const component = renderer.create(<RetrospectiveParticipants participants={participants} />);
    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });

  it('passes all props to Input', () => {
    const { getByText } = render(<RetrospectiveParticipants participants={participants} />);
    const buttonElement = getByText(/Participants/i);
    expect(buttonElement).toBeInTheDocument();
  });
});