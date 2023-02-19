import React, { Component } from 'react';

export class Orders extends Component {

    constructor(props) {
        super(props);
        this.state = { orders: [], loading: true };
    }

    componentDidMount() {
        this.getOrders();
    }

    static renderOrderTable(orders) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                    </tr>
                </thead>
                <tbody>
                    {orders.map(order =>
                        <tr key={order.Order_ID}>
                            <td>{order.Name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Orders.renderOrderTable(this.state.orders);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
    async getOrders() {
        const response = await fetch('order');
        const data = await response.json();
        this.setState({ orders: data, loading: false });
    }
}
