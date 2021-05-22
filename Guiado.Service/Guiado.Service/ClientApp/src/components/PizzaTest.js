import React, { Component } from 'react';

export class Pizza extends Component {
    static displayName = Pizza.name;
    constructor(props) {
        super(props);
        this.state = {
            isHungry: true,
            topping: "Pepperoni",
            slices: 8
        };
        this.eatSlice = this.eatSlice.bind(this);
        this.buySlice = this.buySlice.bind(this);
    }

    eatSlice() {
        const totalSlices = this.state.slices - 1;
        this.setState({
            slices: totalSlices
        });
    }

    buySlice() {
        const totalSlices = this.state.slices + 1;
        this.setState({
            slices: totalSlices
        });
    }

    render() {
        return (
            <div>
                <p>Are you hungry? {this.state.isHungry ? "Yes" : "No"}</p>
                <p>What topping do you want? {this.state.topping}</p>
                <p>Slices Left: {this.state.slices}</p>
                <Button action={this.eatSlice} label="Eat a slice" />
                <Button action={this.buySlice} label="Buy a slice" />
            </div>
        )
    }
}

const Button = ({ action, label }) => (
    <button onClick={() => action()}>{label}</button>
)