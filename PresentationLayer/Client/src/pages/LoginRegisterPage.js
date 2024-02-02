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
      <div className='w-full h-full p-16 flex-col flex justify-center gap-5 items-center text-sm text-black'>
        <h1 className='text-lime-200 text-lg'>Login</h1>
        <input type="email" className='rounded-full px-5 py-1' value={loginEmail} onChange={(e) => this.setState({ loginEmail: e.target.value })} placeholder="Email" />
        <input type="password" className='rounded-full px-5 py-1' value={loginPassword} onChange={(e) => this.setState({ loginPassword: e.target.value })} placeholder="Password" />
        <button className='rounded-full px-5 py-1 bg-lime-600 text-white shadow-md' onClick={this.handleLogin}>Login</button>

        <h1 className="text-lime-100 text-xs">----------&nbsp;&nbsp;&nbsp;OR&nbsp;&nbsp;&nbsp;----------</h1>

        <h1 className='text-lime-200 text-lg'>Register</h1>
        <input type="text" className='rounded-full px-5 py-1' value={registerName} onChange={(e) => this.setState({ registerName: e.target.value })} placeholder="Name" />
        <input type="email" className='rounded-full px-5 py-1' value={registerEmail} onChange={(e) => this.setState({ registerEmail: e.target.value })} placeholder="Email" />
        <input type="password" className='rounded-full px-5 py-1' value={registerPassword} onChange={(e) => this.setState({ registerPassword: e.target.value })} placeholder="Password" />
        <button className='rounded-full px-5 py-1 bg-lime-600 text-white shadow-md' onClick={this.handleRegister}>Register</button>
      </div >
    );
  }
}