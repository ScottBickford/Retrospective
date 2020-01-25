import React from 'react';
import { render } from '@testing-library/react';
import renderer from 'react-test-renderer';
import RetrospectiveList from './RetrospectiveList';

const data = {list: [{name: 'test', summary: 'test', date: '2012-02-02', participants: ['Person 1', 'Person 2']}]};
describe('RetrospectiveList', () => {
  test('snapshot renders', () => {    
    const component = renderer.create(<RetrospectiveList data={data} />);
    let tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });

  it('passes all props to Input', () => {
    const { getByText } = render(<RetrospectiveList data={data} />);
    const buttonElement = getByText(/Person 1/i);
    expect(buttonElement).toBeInTheDocument();
  });
});