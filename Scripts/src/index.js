import React from 'react';
import ReactDOM from 'react-dom';

export const MyName = () => {
    return (
        <div>
            Hello From React.js with Webpack and Babel!
        </div>
    )
}

export default MyName

 
ReactDOM.render(<MyName />, document.getElementById("root"));