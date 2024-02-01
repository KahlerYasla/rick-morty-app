import React, { Component } from 'react';

export class LoginRegisterPage extends Component {
  static displayName = LoginRegisterPage.name;

  constructor(props) {
    super(props);
    this.state = {
      loginEmail: '',
      loginPassword: '',
      registerName: '',
      registerEmail: '',
      registerPassword: ''
    };
  }

  handleLogin = () => {
    // Handle login logic here
    const { loginEmail, loginPassword } = this.state;
    // Perform login API call or any other login logic
    console.log('Login:', loginEmail, loginPassword);
  }

  handleRegister = () => {
    // Handle register logic here
    const { registerName, registerEmail, registerPassword } = this.state;
    // Perform register API call or any other register logic
    console.log('Register:', registerName, registerEmail, registerPassword);
  }

  render() {
    const { loginEmail, loginPassword, registerName, registerEmail, registerPassword } = this.state;

    return (
      <div>
        <h1>Login</h1>
        <input type="email" value={loginEmail} onChange={(e) => this.setState({ loginEmail: e.target.value })} placeholder="Email" />
        <input type="password" value={loginPassword} onChange={(e) => this.setState({ loginPassword: e.target.value })} placeholder="Password" />
        <button onClick={this.handleLogin}>Login</button>

        <h1>Register</h1>
        <input type="text" value={registerName} onChange={(e) => this.setState({ registerName: e.target.value })} placeholder="Name" />
        <input type="email" value={registerEmail} onChange={(e) => this.setState({ registerEmail: e.target.value })} placeholder="Email" />
        <input type="password" value={registerPassword} onChange={(e) => this.setState({ registerPassword: e.target.value })} placeholder="Password" />
        <button onClick={this.handleRegister}>Register</button>
      </div>
    );
  }
}