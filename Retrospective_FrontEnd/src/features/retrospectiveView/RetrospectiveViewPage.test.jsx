import React from 'react';
import { render } from '@testing-library/react';
import renderer from 'react-test-renderer';
import RetrospectiveViewPage from './RetrospectiveViewPage';

const match = { params: { retrospectiveId: 1 } };
describe('RetrospectiveViewPage', () => {
  test('snapshot renders', () => {
    const component = renderer.create(<RetrospectiveViewPage match={match} />);
    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });

  it('passes all props to Input', () => {
    const { getByText } = render(<RetrospectiveViewPage match={match} />);
    const buttonElement = getByText(/View Retrospective/i);
    expect(buttonElement).toBeInTheDocument();
  });
});
