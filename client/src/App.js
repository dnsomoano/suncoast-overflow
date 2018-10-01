import React, { Component } from "react";
import "./App.css";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import TopQuestions from "./Components/TopQuestions";
import QuestionDetail from "./Components/QuestionDetail";
import AskQuestion from "./Components/AskQuestion";
import InterestingQuestions from "./Components/InterestingQuestions";
import HotQuestions from "./Components/HotQuestions";
// TODO work  on this v
import TopNav from "./Components/TopNav";
import SearchQuestion from "./Components/SearchQuestion";

class App extends Component {
  render() {
    return (
      <Router>
        <div>
          <section className="App">
            <TopNav />
          </section>
          <section className="Nav-bar">
          <h2>Top Questions</h2>
          <button>Ask Question</button>
          <section/>
            <ul class="Questions-nav-bar-ul">
              <li>
                <Link to="/topquestions">
                  <button type="button">Top</button>
                </Link>
              </li>
              <li>
                <Link to="/interestingquestions">
                <button type="button">Interesting</button>
                </Link>
              </li>
              <li>
                <Link to="/hotquestions">
                <button type="button">Hot</button>
                </Link>
              </li>
            </ul>
          </section>
          <Switch>
            <Route path="/topquestions" exact component={TopQuestions} />
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
