import React, { Component } from "react";
import "../styling/TopQuestions.css";
import { Link } from "react-router-dom";

class TopQuestions extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      id: 0,
      upVote: 0,
      downVote: 0
    };
  }
  componentDidMount() {
    this.getQuestions();
  }

  // GET latest questions from QuestionsTable
  getQuestions = () => {
    fetch("https://localhost:5001/api/questions")
      .then(resp => resp.json())
      .then(questions => {
        console.log(questions);
        this.setState({ data: questions });
      });
  };

  // PATCH up vote to question to QuestionsTable
  handleUpVoteQuestion = id => {
    const PATCH_UP_URL = `https://localhost:5001/api/questions/up/${id}`;
    fetch(PATCH_UP_URL, {
      // mode: "no-cors",
      method: "PATCH",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        upVoteQuestion: this.state.upVote
      })
    })
      .then(resp => resp.json())
      .then(_ => {
        this.getQuestions();
      });
  };

  // PATCH down vote to question to QuestionsTable
  handleDownVoteQuestion = id => {
    const PATCH_DOWN_URL = `https://localhost:5001/api/questions/down/${id}`;
    fetch(PATCH_DOWN_URL, {
      // mode: "no-cors",
      method: "PATCH",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        upVoteQuestion: this.state.downVote
      })
    })
      .then(resp => resp.json())
      .then(_ => {
        this.getQuestions();
      });
  };

  handleChange = e => {
    this.setState({
      [e.target.name]: e.target.value
    });
  };

  render() {
    return (
      <section>
        <section>
          {this.state.data.map((question, i) => {
            return (
              <section key={i} className="top-questions">
                <section className="vote-buttons">
                  {/* TODO add event handlers to up vote/down vote buttons */}
                  <button
                    name="upVote"
                    onClick={() => {
                      this.handleUpVoteQuestion(question.id);
                    }}
                  >
                    {question.upVoteQuestion}
                  </button>
                  <button
                    name="downVote"
                    onClick={() => {
                      this.handleDownVoteQuestion(question.id);
                    }}
                  >
                    {question.downVoteQuestion}
                  </button>
                </section>
                <Link
                  to={`/questions/${question.id}/${question.titleOfQuestion}`}
                >
                  <header>{question.titleOfQuestion}</header>
                </Link>
                <section className="date-and-user">
                  <header>Asked {question.dateOfQuestion}</header>
                  <header>by {question.user}</header>
                </section>
              </section>
            );
          })}
        </section>
      </section>
    );
  }
}

export default TopQuestions;
