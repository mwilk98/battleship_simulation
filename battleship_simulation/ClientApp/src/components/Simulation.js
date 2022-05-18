import React, { Component } from 'react';

export class Simulation extends Component {
    static displayName = Simulation.name;

    constructor(props) {
        super(props);
        this.state = { playerOneBoard: [], playerTwoBoard: [], events: [], loading: true };
    }

    componentDidMount() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title: 'React POST Request Example' })
        };
        fetch('battleshipgamesim', requestOptions);
        this.interval = setInterval(() => {
            this.populateWeatherData();
            console.log(this.state.events);
        }, 1000);

    }

    componentWillUnmount() {
        clearInterval(this.interval);
    }

    static renderForecastsTable(playerOneBoard, playerTwoBoard, events) {
        return (
            <div className="sides">
                <div className="left">
                    {playerOneBoard.map((board, index) => {
                        return (
                            <div>
                                {board.map((rect, sIndex) => {
                                    if (rect === 'e') {
                                        return <div className="rectangle"> "" </div>;
                                    }
                                    if (rect === 'c' || rect === 'b' || rect === 'd' || rect === 's' || rect === 'p') {
                                        return <div className="rectangle2"> {rect} </div>;
                                    }
                                    if (rect === 'm') {
                                        return <div className="rectangle3"> "" </div>;
                                    }
                                    if (rect === 't') {
                                        return <div className="rectangle4"> "" </div>;
                                    }
                                })}
                            </div>
                        );
                    })}
                </div>
                <div className="right">
                    {playerTwoBoard.map((board, index) => {
                        return (
                            <div>
                                {board.map((rect, sIndex) => {
                                    if (rect === 'e') {
                                        return <div className="rectangle"> "" </div>;
                                    }
                                    if (rect === 'c' || rect === 'b' || rect === 'd' || rect === 's' || rect === 'p') {
                                        return <div className="rectangle2"> {rect} </div>;
                                    }
                                    if (rect === 'm') {
                                        return <div className="rectangle3"> "" </div>;
                                    }
                                    if (rect === 't') {
                                        return <div className="rectangle4"> "" </div>;
                                    }
                                })}
                            </div>
                        );
                    })}
                </div>
                <div className = "t">
                    <p> Battlelog: </p>
                    {events.map((event, index) => {
                        return (
                            <div>
                                {event}
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
            : Simulation.renderForecastsTable(this.state.playerOneBoard, this.state.playerTwoBoard, this.state.events);

        return (
            <div>
                <h1 id="tabelLabel" >Battleship Game Simulation</h1>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('battleshipgamesim');
        const data = await response.json();
        console.log(data);
        this.setState({ playerOneBoard: data.playerOneBoard, playerTwoBoard: data.playerTwoBoard, events: data.events, loading: false });
    }
}
