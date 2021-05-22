import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: "ue", loading: true };
    }

    async componentDidMount() {
        await this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    <tr key={Date.now()}>
                        <td>{forecasts}</td>
                    </tr>
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        try {
            const response = await fetch('api/v1/test');
            if (!response.ok) {
                throw Error(response.statusText);
            }
            const data = await response.text();
            console.log(data);
            this.setState({ forecasts: data, loading: false });

        } catch (error) {
            console.log(error);
        }
    }
}
