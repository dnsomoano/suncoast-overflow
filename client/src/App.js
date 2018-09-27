import React, { Component } from "react";
import "./App.css";
import {BrowserRouter as Router} from 'react-router-dom'

class App extends Component {
  render() {
    return (
      <div>
        <section className="App-header">
          <img
            src="./images/stack-overflow.png"
            className="App-logo"
            alt="logo"/>
          <input type="text" placeholder="Search"></input>
          <button>Submit</button>
        </section>
        <section className="App">
          <h2>Type in a title</h2>
          <input type="text" placeholder="Title" />
          <p>Type in your question</p>
          <textarea name="Question" />
          <h2>Type in your answer</h2>
          <textarea height="200" width="600" name="Question" />
          <br />
          <br />
        <section>
          <button>Up Vote</button>
          <button>Down Vote</button>
        </section>
        </section>
      </div>
    );
  }
}

export default App;
