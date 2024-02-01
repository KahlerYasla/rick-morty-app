import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends Component {
  render() {
    return (
      <header>
        <nav className="shadow-xl w-full fixed bg-lime-950 z-10">  {/* Navbar */}

          {/* Logo Image */}
          <div className="justify-center align-middle md:inline-flex hidden  items-center md:ml-7">
            <img src="logo.png" alt="Rick and Morty Logo" className="md:h-12" />
          </div>

          {/* Links */}
          <ul className="flex justify-center md:inline-flex m-3 mb-3 md:mx-8 md:my-5 md:mb-3 p-0 gap-6 h-full">
            <div>
              <NavLink tag={Link} to="/" className="text-lime-100">
                Home
              </NavLink>
            </div>
            <div>
              <NavLink tag={Link} to="/listings" className="text-lime-100">
                Characters
              </NavLink>
            </div>
            <div>
              <NavLink tag={Link} to="/listings" className="text-lime-100">
                Episodes
              </NavLink>
            </div>
            <div>
              <NavLink tag={Link} to="/listings" className="text-lime-100">
                Favorites
              </NavLink>
            </div>
          </ul>

          <form className="flex justify-center md:inline-flex items-center pb-4 p-0 mx-3 md:pb-0 md:mx-5 md:mb-3 h-full">
            <input className="border-lime-600 border bg-transparent text-white placeholder-lime-800 rounded-md p-2 w-64" type="text" placeholder="Search..." />   {/* Search Input */}
            <button className="bg-lime-600 shadow-xl text-white rounded-md p-2 ml-2" type="submit">Search</button>  {/* Search Button */}
          </form>
        </nav>
      </header>
    );
  }
}
