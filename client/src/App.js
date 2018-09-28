import React, { Component } from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import InterestingQuestions from "./Components/InterestingQuestions";
import TopQuestions from "./Components/TopQuestions";
import HotQuestions from "./Components/HotQuestions";



class App extends Component {
  render() {
    return (
      <Router>
        <div>
          <section className="App">
            <section className="App-header">
              <img
                src="./images/stack-overflow.png"
                className="App-logo"
                alt="logo" />
              <input type="text" placeholder="Search"></input>
              <button>Submit</button>
            </section>
          </section>
          <Switch>
            <Route path="/InterestingQuestions" exact component={InterestingQuestions} />
            <Route path="/TopQuestions" exact component={TopQuestions} />
            <Route path="/HotQuestions" exact component={HotQuestions} />
          </Switch>
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
      </Router>
    );
  }
}

export default App;
