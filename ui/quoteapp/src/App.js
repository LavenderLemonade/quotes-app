import logo from './logo.svg';
import './App.css';
import { Component } from 'react';

class App extends Component {

  constructor(props) {
    super(props);
    this.state = { quotes: [] }
  }

  API_URL = "http://localhost:5049/";

  componentDidMount() {
    this.refreshQuotes();
  }

  async refreshQuotes() {
    fetch(this.API_URL + "api/QuotesApp/GetRandomQuote").then(response => response.json())
      .then(data => {
        this.setState({ quotes: data });
      })
  }

  render() {
    const { quotes } = this.state;
    return (
      <div className="App">

        <h2> Abby Quotes </h2>

        {quotes.map(quote =>
          <p>
            <b> * {quote.Quote} </b>
          </p>)}

        <button onClick={() => this.refreshQuotes()}> hey hey</button>

      </div>
    );
  }
}
export default App;
