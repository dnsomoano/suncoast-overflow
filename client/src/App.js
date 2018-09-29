import React, { Component } from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
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
                alt="logo"
              />
              <input type="text" placeholder="Search" />
              <button>Submit</button>
            </section>
          </section>
          <nav className="Nav-bar">
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/InterestingQuestions">Interesting Questions</Link>
              </li>
              <li>
                <Link to="/HotQuestions">Hot Questions</Link>
              </li>
            </ul>
          </nav>
          <Switch>
            <Route path="/" exact component={TopQuestions} />
            <Route
              path="/InterestingQuestions"
              exact
              component={InterestingQuestions}
            />
            <Route path="/HotQuestions" exact component={HotQuestions} />
          </Switch>
          <section className="App" />
        </div>
      </Router>
    );
  }
}

export default App;
