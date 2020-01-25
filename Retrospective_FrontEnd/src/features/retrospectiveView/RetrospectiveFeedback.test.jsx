import React from 'react';
import { render } from '@testing-library/react';
import renderer from 'react-test-renderer';
import { RetrospectiveFeedback } from './RetrospectiveFeedback';

const feedback = [{feedbackId: 1, name: 'Person 1', body: 'Test Body', feedbackType: 'Positive'}];
describe('RetrospectiveFeedback', () => {
  test('snapshot renders', () => {    
    const component = renderer.create(<RetrospectiveFeedback feedback={feedback} />);
    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });

  it('passes all props to Input', () => {
    const { getByText } = render(<RetrospectiveFeedback feedback={feedback} />);
    const buttonElement = getByText(/Person 1/i);
    expect(buttonElement).toBeInTheDocument();
  });
});