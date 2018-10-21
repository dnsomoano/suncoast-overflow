import React, { Component } from "react";

class SearchResults extends Component {
  constructor(props) {
    super(props);
    this.state = {
      searchTerm: this.props.searchTerm,
      searchResults: []
    };
  }

  //   componentDidMount() {
  //     fetch("https://localhost:5001/api/search?q=" + this.state.searchTerm)
  //       .then(resp => resp.json())
  //       .then(results => {
  //         console.log(results);
  //         this.setState({
  //           searchResults: results
  //         });
  //       });
  //   }

  //   //   // handle event for search bar
  //   //   handleSearch = e => {
  //   //     e.preventDefault();
  //   //   };

  //   // handle event for search input
  //   handleChange = e => {
  //     this.setState({
  //       [e.target.name]: e.target.value
  //     });
  //   };
  render() {
    return (
      <div>
        {this.state.searchResults.map((question, i) => {
          return <section key={i}>{question}</section>;
        })}
      </div>
    );
  }
}

export default SearchResults;
