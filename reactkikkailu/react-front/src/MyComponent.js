import React from 'react';

class MyComponent extends React.Component {
    render(){

        var randomJunk = <p>Sekalaista pulinaa.</p>;
        var luvut =[];
        for (let i=1; i<=10; i++)
        {
            luvut.push(<p>{i}</p>);
        }

        return <div><h1>Ikioma komponentti! </h1> {randomJunk}{luvut}</div> ;
    }
}

export default MyComponent;