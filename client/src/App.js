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
          <section className="Nav-bar">
          <h2>Top Questions</h2>
          <button>Ask Question</button>
          <section/>
            <ul class="Questions-nav-bar-ul">
              <li>
                <Link to="/">
                  <button type="button">Home</button>
                </Link>
              </li>
              <li>
                <Link to="/InterestingQuestions">
                <button type="button">Interesting</button>
                </Link>
              </li>
              <li>
                <Link to="/HotQuestions">
                <button type="button">Hot</button>
                </Link>
              </li>
            </ul>
          </section>
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
