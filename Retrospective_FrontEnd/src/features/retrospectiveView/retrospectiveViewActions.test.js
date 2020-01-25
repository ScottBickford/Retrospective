import { retrospectiveItemReducer } from "./retrospectiveViewActions";

const item = {retrspectiveId: 1, name: 'Test'}

describe('Item Reducer', () => {
  it('should set an object', () => {
    const state = { item: {}, error: null };
    const newState = retrospectiveItemReducer(state, {
      type: 'SET_ITEM',
      item
    });

    expect(newState).toEqual({ item, error: null });
  });

  it('should reset the error if list is set', () => {
    const state = { item: null, error: 'An error occured' };
    const newState = retrospectiveItemReducer(state, {
      type: 'SET_ITEM',
      item
    });

    expect(newState).toEqual({ item, error: null });
  });

  it('should set the error', () => {
    const state = { item: null, error: null };
    const newState = retrospectiveItemReducer(state, {
      type: 'SET_ITEM_ERROR'
    });

    expect(newState.error).not.toBeNull();
  });
});