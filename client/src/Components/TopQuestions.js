import React, { Component } from "react";

class TopQuestions extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      user: "",
      title: "",
      body: "",
      upVote: 0,
      downVote: 0,
      date: new Date()
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

  // POST questions to QuestionsTable
  handleAddQuestion = e => {
    fetch("https://localhost:5001/api/questions", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      mode: "no-cors",
      body: JSON.stringify({
        user: this.state.user,
        titleOfQuestion: this.state.title,
        bodyOfQuestion: this.state.body,
        dateOfQuestion: this.state.date
      })
    })
      .then(resp => resp.json())
      .then(_ => {
        this.getQuestions();
      });
  };

  handleChange = e => {
    this.setState({
      [e.target.title]: e.target.value
    });
  };

  render() {
    return (
      <section>
        <div><
        {/* <section>
          {this.state.data.map((questions, i) => {
            return <section key={i}>{questions}</section>;
          })}
      </section>
      </section>
    );
  }
}

export default TopQuestions;
