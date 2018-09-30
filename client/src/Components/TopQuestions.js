import React, { Component } from "react";
import "../styling/TopQuestions.css";

class TopQuestions extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: "",
      title: "",
      body: "",
      upVote: 0,
      downVote: 0,
      date: new Date(),
      data: [{}]
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

  // POST question to QuestionsTable
  handleAddQuestion = e => {
    e.preventDefault();
    fetch("https://localhost:5001/api/questions", {
      // mode: "no-cors",
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        User: this.state.user,
        titleOfQuestion: this.state.title,
        bodyOfQuestion: this.state.body,
        DateOfQuestion: this.state.date
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
                  <button>{question.upVoteQuestion}</button>
                  <button>{question.downVoteQuestion}</button>
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
        {/* Manny, this section is temporary until i get the post request mechanics working */}
        <section className="post-question">
          <h2>Type in a title</h2>
          <input
            type="text"
            placeholder="Title"
            name="title"
            onChange={this.handleChange}
          />
          <p>Type in your question</p>
          <textarea name="body" onChange={this.handleChange} />
          {/* <textarea height="200" width="600" name="Question" />
          <br />
          <br />
            <button>Up Vote</button>
            <button>Down Vote</button> */}
          <button onClick={this.handleAddQuestion}>Submit Question</button>
        </section>
      </section>
    );
  }
}

export default TopQuestions;
