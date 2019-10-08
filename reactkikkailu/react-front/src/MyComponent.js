import React from 'react';

class MyComponent extends React.Component {

    constructor(props){
        console.log("MyComponent.constructor()");

        super(props);
        this.state = {asiakkaat:[]};
    }

    componentDidMount(){
        console.log("MyComponent.componentDidMount()");
    }

    render() {
        console.log("MyComponent.render()");

        var taulukko = [];
        for (let i = 1; i <= 10; i++) {
            taulukko.push(<table>
                <thead><tr>
                    <th>Pekka</th>
                    <th>Pekkala {i}</th>
                </tr></thead>
                <tbody>
                    
                </tbody>
                
                </table>);
        }

        return <div>{ taulukko }</div>;
    }
}

export default MyComponent;