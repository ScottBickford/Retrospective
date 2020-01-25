import { retrospectiveListReducer } from './retrospectiveListActions';

const list = ['Retrospective 1', 'Retrospective 2', 'Retrospective 3'];

describe('List Reducer', () => {
  it('should set a list', () => {
    const state = { list: [], error: null };
    const newState = retrospectiveListReducer(state, {
      type: 'SET_LIST',
      list
    });

    expect(newState).toEqual({ list, error: null });
  });

  it('should reset the error if list is set', () => {
    const state = { list: [], error: 'An error occured' };
    const newState = retrospectiveListReducer(state, {
      type: 'SET_LIST',
      list
    });

    expect(newState).toEqual({ list, error: null });
  });

  it('should set the error', () => {
    const state = { list: [], error: null };
    const newState = retrospectiveListReducer(state, {
      type: 'SET_ERROR'
    });

    expect(newState.error).not.toBeNull();
  });
});
