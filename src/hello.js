class HelloWorld extends React.Component {
    render() {
        return <div>Hello from React!</div>;
    }
}

const containerElement = document.getElementById('content');
ReactDOM.render(<HelloWorld />, containerElement);