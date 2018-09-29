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
        <div>These are the Top Questions Developers are asking underflow</div>
        <section className="ask-question">
          <h2>Type in a title</h2>
          <input
            type="text"
            placeholder="Title"
            name="title"
            onChange={this.handleChange}
          />
          <p>Type in your question</p>
          <textarea name="body" onChange={this.handleChange} />
          <h2>Type in your answer</h2>
          {/* <textarea height="200" width="600" name="Question" />
          <br />
          <br />
            <button>Up Vote</button>
            <button>Down Vote</button> */}
          <button onClick={this.handleAddQuestion}>Submit Question</button>
        </section>
        <section>
          {this.state.data.map((question, i) => {
            return (
              <section key={i}>
                <header>{question.title}</header>
              </section>
            );
          })}
        </section>
      </section>
    );
  }
}

export default TopQuestions;
