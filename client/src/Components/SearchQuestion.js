import React, { Component } from "react";

class SearchQuestion extends Component {
  constructor(props, context) {
    super(props, context);
    this.state = {
      searchTitle: this.props.match.params.title
    };
  }

  componentDidMount() {
    this.getResults();
  }

  // TODO pass down title as props to search question comp
  // GET results from QuestionsTable
  getResults = () => {
    const SEARCH_BASE_URL = "https://localhost:5001/api/search?q=";
    fetch(SEARCH_BASE_URL + `${this.state.searchTitle}`)
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
      <section>
        <header>Results</header>
        {this.state.data.map((question, i) => {
          return (
            <section>
              <header>{question.title}</header>
              <section>{question.body}</section>
            </section>
          );
        })}
      </section>
    );
  }
}

export default SearchQuestion;
