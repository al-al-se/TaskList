import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'

import axios from 'axios';

import {useMemo,  useState, useEffect } from "react";

import Table from "./components/Table";

function func()
{
  
}

export default class App extends Component {
  static displayName = App.name;

  render () {

    const columns = useMemo(
      () => [
        {
         
          Header: "Tasks",
          
          columns: [
            {
              Header: "Id",
              accessor:"task.Id",
              show: false
            },
            {
              Header: "Name",
              accessor:"task.Name"
            },
            {
              Header: "Begin",
              accessor:"task.Begin"
            },
            {
              Header: "End",
              accessor:"task.End"
            },
            {
              Header: "Status",
              accessor:"task.Status"
            }
          ]
        }
      ]
    );

    const [data, setData] = useState([]);

    // Using useEffect to call the API once mounted and set the data
    useEffect(() => {
      (async () => {
        const result = await axios("https://localhost:5001/Task/GetAll");
        setData(result.data);
      })();
    }, []);

    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Table columns={columns} data={data} />
      </Layout>    
    );
  }
}
