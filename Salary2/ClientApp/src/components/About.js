import React, { Component } from 'react';
import image from '../assets/david.jpg';

export class About extends Component {
  static displayName = About.name;

  constructor(props) {
    super(props);

  }


  render() {
    return (
      <div>
        <h1>About</h1>

        <img src={image} />
        <p className="goes-to-center">This application was built by David Castro.</p>

        <p className="goes-to-center" aria-live="polite">You can find more information about him here: <strong><a target="_blank" href="https://www.linkedin.com/in/dcastro-especialista-sistemas/">LinkedIn - David Castro</a></strong></p>

      </div>
    );
  }
}
