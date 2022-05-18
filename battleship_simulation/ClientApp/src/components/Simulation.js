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
            body: JSON.stringify({ title: 'Activate simulation' })
        };
        /* request activating simulation */
        fetch('battleshipgamesim', requestOptions);

        /* interval after which simulation is updated from the server */
        this.interval = setInterval(() => {
            /* call of method that populates game data */
            this.populateGameData();
        }, 1000);

    }

    componentWillUnmount() {
        /* clearing interval */
        clearInterval(this.interval);

    }

    static renderForecastsTable(playerOneBoard, playerTwoBoard, events) {
        return (
            /* div containing boards */
            <div className="sides">
                {/* div containing first board*/}
                <div className="left">
                    <h1>Player 1</h1>
                    {playerOneBoard.map((board, index) => {
                        return (
                            <div>
                                {board.map((rect, sIndex) => {
                                    switch (rect) {
                                        case 'e':
                                            {/* div containing water rect of the gameboard*/ }
                                            return <div className="water"> "" </div>
                                        case 'c':
                                        case 'b':
                                        case 'd':
                                        case 's':
                                        case 'p':
                                            {/* div containing ship rect of the gameboard*/ }
                                            return <div className="ship"> {rect} </div>;
                                        case 'm':
                                            {/* div containing missed shot rect of the gameboard*/ }
                                            return <div className="miss"> "" </div>;
                                        case 'h':
                                            {/* div containing registered hit rect of the gameboard*/ }
                                            return <div className="hit"> "" </div>;
                                    }
                                })}
                            </div>
                        );
                    })}
                </div>
                {/* div containing second board*/}
                <div className="right">
                    <h1>Player 2</h1>
                    {playerTwoBoard.map((board, index) => {
                        return (
                            <div>
                                {board.map((rect, sIndex) => {
                                    switch (rect) {
                                        case 'e':
                                            {/* div containing water rect of the gameboard*/ }
                                            return <div className="water"> "" </div>
                                        case 'c':
                                        case 'b':
                                        case 'd':
                                        case 's':
                                        case 'p':
                                            {/* div containing ship rect of the gameboard*/ }
                                            return <div className="ship"> {rect} </div>;
                                        case 'm':
                                            {/* div containing missed shot rect of the gameboard*/ }
                                            return <div className="miss"> "" </div>;
                                        case 'h':
                                            {/* div containing registered hit rect of the gameboard*/ }
                                            return <div className="hit"> "" </div>;
                                    }
                                })}
                            </div>
                        );
                    })}
                </div>
                {/* div containing battlelog look*/}
                <div className = "battlelog">
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

    /* methond populating player boards and gamelog taking data from the server*/ 
    async populateGameData() {
        const response = await fetch('battleshipgamesim');
        const data = await response.json();
        this.setState({ playerOneBoard: data.playerOneBoard, playerTwoBoard: data.playerTwoBoard, events: data.events, loading: false });
    }
}
