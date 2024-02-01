import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends Component {
  render() {
    return (
      <header>
        <nav className="shadow-xl shadow-black w-full fixed bg-lime-950 z-10 h-30 rounded-3xl justify-self-center">  {/* Navbar */}

          {/* Logo Image */}
          <div className="justify-center align-middle md:inline-flex hidden  items-center md:ml-7">
            <img src="logo.png" alt="Rick and Morty Logo" className="md:h-10" />
          </div>

          {/* Links */}
          <ul className="flex justify-center md:inline-flex m-3 mb-3 md:mx-8 md:my-3 md:mb-3 p-0 gap-6 h-full">
            <div>
              <NavLink tag={Link} to="/" className="text-lime-100 text-xs">
                Login | Register
              </NavLink>
            </div>
            <div>
              <NavLink tag={Link} to="/listing" className="text-lime-100 text-xs">
                Episodes
              </NavLink>
            </div>
            <div>
              <NavLink tag={Link} to="/listing" className="text-lime-100 text-xs">
                Characters
              </NavLink>
            </div>
            <div>
              <NavLink tag={Link} to="/listing" className="text-lime-100 text-xs">
                Favorites
              </NavLink>
            </div>
          </ul>

          <form className="flex justify-center md:inline-flex items-center pb-4 p-0 mx-3 md:pb-0 md:mx-5 md:mb-3 h-full">
            <input className="border-lime-600 border bg-transparent text-white placeholder-lime-800 placeholder-opacity-50 rounded-full p-2 w-[70%] h-6 text-xs placeholder:text-xs" type="text" placeholder="Search..." />   {/* Search Input */}
            <button className="bg-lime-600 shadow-xl text-white rounded-3xl px-3 ml-2 h-6 text-xs" type="submit">Search</button>  {/* Search Button */}
          </form>
        </nav>
      </header >
    );
  }
}
