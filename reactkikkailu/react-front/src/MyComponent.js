import React from 'react';

class MyComponent extends React.Component {

    constructor(props){
        console.log("MyComponent.constructor()");

        super(props);
        this.state = {asiakkaat:[]};
    }

    componentDidMount(){
        console.log("MyComponent.componentDidMount()");

        let reactComponent = this;

        fetch('https://localhost:5001/api/pilipali')
        .then(response => response.json())
        .then(json => {
            console.log("Asiakasdata ladattu.");
        
        reactComponent.setState({asiakkaat:json});
        });


    }

    render() {
        console.log("MyComponent.render()");

        let customerCount = this.state.asiakkaat.length;
        
        var taulukko = [];
        for (let i=0; i < customerCount; i++){
            let customer = this.state.asiakkaat[i];

            taulukko.push(<tr>
            <td>{customer.customerId}</td>
            <td>{customer.companyName}</td>
            <td>{customer.country}</td>
            <td>{customer.address}</td>
            </tr>);
        }
        
        return <div>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Asiakkaan id</th>
                        <th>Yrityksen nimi</th>
                        <th>Maa</th>
                        <th>Osoite</th>
                    </tr>
                </thead>
                <tbody>
                    {taulukko}
                </tbody>
            </table>
        </div>;

        
    }
}

export default MyComponent;