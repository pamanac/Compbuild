import React from 'react';
import ReactDOM from 'react-dom';
import Example from './components/Example';

export const MyName = () => {
    return (
        <div>
            Hello From React.js with Webpack and Babel!
            <Example />
        </div>
    )
}

export default MyName

 
ReactDOM.render(<MyName />, document.getElementById("root"));