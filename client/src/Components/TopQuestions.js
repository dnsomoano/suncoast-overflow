import React, { Component } from "react";
import "../styling/TopQuestions.css";

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

  // TODO add string interpolation for id to perform patch request
  // PATCH question to QuestionsTable
  handleSubmitQuestion = e => {
    e.preventDefault();
    fetch("https://localhost:5001/api/questions", {
      // mode: "no-cors",
      method: "PATCH",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        upVoteQuestion: this.state.upVote,
        DownVoteQuestion: this.state.downVote
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
                  <button name="upVote">{question.upVoteQuestion}</button>
                  <button name="downVote">{question.downVoteQuestion}</button>
                </section>
                <header>{question.titleOfQuestion}</header>
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
