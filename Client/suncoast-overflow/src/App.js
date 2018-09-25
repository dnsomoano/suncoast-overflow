import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro"></p>
      <form>
      <span>
        <h2>Type in a title</h2><input type="text" placeholder="Title"></input>
      </span>
      <p>Type in your question</p>
      <textarea
        height="200"
        width="600"
        name="Question"/>
      <p>Type in your answer</p>
      <textarea
        height="200"
        width="600"
        name="Question"/>  
        <br></br>
        <br></br>
      <section>
      <button>Up Vote</button>
      <button>Down Vote</button>
      </section>
      </form>
      </div>
    );
  }
}

export default App;
