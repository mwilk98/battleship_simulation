import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
      this.state = { forecasts: [], forecasts2: [], loading: true };
  }

    componentDidMount() {
        this.interval = setInterval(() => {
            this.populateWeatherData();
            console.log(this.state.forecasts);
        }, 1000);

    }

    componentWillUnmount() {
        clearInterval(this.interval);
    }

  static renderForecastsTable(forecasts,forecasts2) {
      return (
          <div className="sides">
              <div className="left">
                  {forecasts.map((items, index) => {
                      return (
                          <div>
                              {items.map((subItems, sIndex) => {
                                  if (subItems === 'e') {
                                      return <div className="rectangle"> </div>;
                                  }
                                  if (subItems === 'f') {
                                      return <div className="rectangle2"> {subItems} </div>;
                                  }
                                  if (subItems === 'g') {
                                      return <div className="rectangle3"> {subItems} </div>;
                                  }
                                  if (subItems === 'h') {
                                      return <div className="rectangle4"> {subItems} </div>;
                                  }
                              })}
                          </div>
                      );
                  })}
              </div>
              <div className="right">
                  {forecasts2.map((items, index) => {
                      return (
                          <div>
                              {items.map((subItems, sIndex) => {
                                  if (subItems === 'e') {
                                      return <div className="rectangle2">  </div>;
                                  }
                                  if (subItems === 'f') {
                                      return <div className="rectangle2"> {subItems} </div>;
                                  }
                                  if (subItems === 'g') {
                                      return <div className="rectangle3"> {subItems} </div>;
                                  }
                                  if (subItems === 'h') {
                                      return <div className="rectangle4"> {subItems} </div>;
                                  }
                              })}
                          </div>
                      );
                  })}
                  </div>
              </div>         
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : FetchData.renderForecastsTable(this.state.forecasts, this.state.forecasts2);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
      const data = await response.json();
      console.log(data);
      this.setState({ forecasts: data.board, forecasts2: data.board2, loading: false });
    }
}
