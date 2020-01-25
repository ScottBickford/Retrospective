import axios from 'axios';
import { format } from 'date-fns';
import { baseUrl } from '../../common';

export const retrospectiveListReducer = (state, action) => {
  if (action.type === 'SET_ERROR') {
    return { ...state, list: [], error: action.error };
  }

  if (action.type === 'SET_LIST') {
    return { ...state, list: action.list, error: null };
  }

  throw new Error();
};

export const getRetrospectives = async (date, dispatch) => {
  const dateparam = date ? `?date=${format(new Date(date), 'yyyy-LL-dd')}` : '';
  axios
    .get(`${baseUrl}retrospective/GetAll${dateparam}`)
    .then(response => {
      dispatch({ type: 'SET_LIST', list: response.data.retrospectives });
    })
    .catch(error => {
      dispatch({ type: 'SET_ERROR', error: error.response || error });
    });
};
