import React, { Component } from "react";
import "../App.css";
import { Link } from "react-router-dom";

class TopNav extends Component {
  render() {
    return (
      <div>
        <section className="App-header">
          <img
            src="./images/stack-overflow.png"
            className="App-logo"
            alt="logo"
          />
          <section className="search-bar">
            <form>
              <input type="Search" placeholder="Search" />
              {/* TODO pass down title as props to search question comp */}
              <Link to="/Search/:title">
                <button>Submit</button>
              </Link>
            </form>
          </section>
        </section>
      </div>
    );
  }
}

export default TopNav;
