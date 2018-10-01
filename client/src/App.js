import React, { Component } from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import TopQuestions from "./Components/TopQuestions";
import QuestionDetail from "./Components/QuestionDetail";
import AskQuestion from "./Components/AskQuestion";
import InterestingQuestions from "./Components/InterestingQuestions";
import HotQuestions from "./Components/HotQuestions";
// TODO add SearchQuestion component

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
            <section className="top-questions-header">
              <h2>Top Questions</h2>
              <Link to="/ask">
                <button className="ask-button">Ask Question</button>
              </Link>
            </section>
            <section>
              <ul className="Questions-nav-bar-ul">
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
          </section>
          <Switch>
            <Route path="/" exact component={TopQuestions} />
            <Route path="/ask" exact component={AskQuestion} />
            <Route
              path="/questions/:id/:title"
              exact
              component={QuestionDetail}
            />
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
