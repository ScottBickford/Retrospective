import axios from 'axios';
import { baseUrl } from '../../common';

export const createRetrospective = (retrospective) => {
  return new Promise((resolve, reject) => {
    axios
    .post(`${baseUrl}retrospective`, retrospective)
    .then(response => {
      resolve(response);
    })
    .catch(error => {
      reject(new Error(error.response ? error.response.data.error : error));      
    });
  })
};
