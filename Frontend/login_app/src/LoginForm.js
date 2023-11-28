import React, { useState } from "react";
import "./LoginForm.css";

const LoginForm = (props) => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();

    props.onSubmit({
      login: login,
      password: password,
    });
  };

  return (
    <form className="form">
      <h1>Login</h1>
      <label htmlFor="name">Name</label>
      <input
        type="text"
        id="login"
        value={login}
        onChange={(e) => setLogin(e.target.value)}
      />
      <label htmlFor="password">Password</label>
      <input
        type="password"
        id="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button className="submit-button" type="submit" onClick={handleSubmit}>
        Continue
      </button>
    </form>
  );
};

export default LoginForm;
