import React, { Component } from "react";
import "../styling/QuestionDetail.css";
class QuestionDetail extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      id: this.props.match.params.id,
      title: this.props.match.params.title,
      user: "",
      body: "",
      upVote: 0,
      downVote: 0,
      answers: []
    };
  }

  componentDidMount() {
    this.getQuestions();
  }

  // GET question and answers from QuestionsTable
  getQuestions = () => {
    const BASE_URL = "https://localhost:5001/api/questions/";
    fetch(BASE_URL + `${this.state.id}`)
      .then(resp => resp.json())
      .then(questions => {
        console.log(questions);
        this.setState({
          data: questions
        });
        this.setState({
          title: questions.titleOfQuestion,
          user: questions.user,
          body: questions.bodyOfQuestion,
          upVote: questions.upVoteQuestion,
          downVote: questions.downVoteQuestion,
          answers: questions.answers
        });
      });
  };

  render() {
    return (
      <div>
        <section className="question-box">
          <header className="question-header">{this.state.title}</header>
          <section className="detail-pane">
            <section className="vote-count">
              {this.state.upVote}
              {this.state.downVote}
            </section>
            <section className="details-body">
              {this.state.body}
              <section className="user-details">{this.state.user}</section>
            </section>
          </section>
        </section>
        {this.state.answers.map((answer, i) => {
          return (
            <section key={i} className="detail-pane">
              <section className="vote-count">
                <header>{answer.UpVoteAnswer}</header>
                <header>{answer.downVoteAnswer}</header>
              </section>
              <section className="details-body">
                {answer.bodyOfAnswer}
                <header className="user-details">
                  {answer.user}
                  {answer.dateOfAnswer}
                </header>
              </section>
            </section>
          );
        })}
      </div>
    );
  }
}

export default QuestionDetail;
