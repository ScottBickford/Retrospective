import axios from 'axios';
import { baseUrl } from '../../common';

export const retrospectiveItemReducer = (state, action) => {
  if (action.type === 'SET_ITEM_ERROR') {
    return { ...state, item: null, error: action.error };
  }

  if (action.type === 'SET_ITEM') {
    return { ...state, item: action.item, error: null };
  }

  throw new Error();
};

export const getRetrospective = async (retrospectiveId, dispatch) => {
  axios
    .get(`${baseUrl}retrospective/${retrospectiveId}`)
    .then(response => {
      dispatch({ type: 'SET_ITEM', item: response.data });
    })
    .catch(error => {
      dispatch({ type: 'SET_ITEM_ERROR', error: error.response || error });
    });
};

export const addFeedback = (retrospectiveId, feedback) => {
  return new Promise((resolve, reject) => {
    axios
    .post(`${baseUrl}retrospective/${retrospectiveId}`, feedback)
    .then(response => {
      resolve(response);
    })
    .catch(error => {
      reject(new Error(error.response ? error.response.data.error : error));      
    });
  })
};