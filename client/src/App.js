import React, { Component } from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import InterestingQuestions from "./Components/InterestingQuestions";
import QuestionDetail from "./Components/QuestionDetail";
import AskQuestion from "./Components/AskQuestion";
import HotQuestions from "./Components/HotQuestions";

class App extends Component {
  render() {
    return (
      <Router>
        <div className="body">
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
          <section className="main-header-container">
            <section className="header-container">
              <h1>Top Questions</h1>
              <Link to="/questions/ask">
                <button className="ask-question">Ask Question</button>
              </Link>
            </section>
            <section className="Nav-bar">
              <ul className="questions-breadcrumbs">
                <li>
                  <Link to="/">
                    <button type="button">Interesting</button>
                  </Link>
                </li>
                <li>
                  <button type="button">Featured</button>
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
            <Route path="/" exact component={InterestingQuestions} />
            <Route
              path="/questions/:id/:title"
              exact
              component={QuestionDetail}
            />
            <Route path="/questions/ask" exact component={AskQuestion} />
            <Route path="/HotQuestions" exact component={HotQuestions} />
          </Switch>
          <section className="App" />
        </div>
      </Router>
    );
  }
}

export default App;
