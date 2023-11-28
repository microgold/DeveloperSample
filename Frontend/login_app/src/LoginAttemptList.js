// import React from "react";
// import "./LoginAttemptList.css";

// const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

// const LoginAttemptList = (props) => (
// 	<div className="Attempt-List-Main">
// 	 	<p>Recent activity</p>
// 	  	<input type="input" placeholder="Filter..." />
// 		<ul className="Attempt-List">
// 			<LoginAttempt>TODO</LoginAttempt>
// 		</ul>
// 	</div>
// );

// export default LoginAttemptList;

import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {
  const [loginFilter, setLoginFilter] = useState("");

  return (
    <div className="Attempt-List-Main">
      <p>Recent activity</p>
      <input
        type="input"
        placeholder="Filter..."
        onChange={(e) => setLoginFilter(e.target.value)}
        value={loginFilter}
      />
      <ul className="Attempt-List">
        {props.attempts
          .filter((attempt) => {
            return !attempt.login || attempt.login.includes(loginFilter);
          })
          .map((attempt, index) => (
            <div id="`attempt_${index}`">
              <LoginAttempt key="attempt_${index}">
                Login Attempt from <b>{attempt.login}</b>
              </LoginAttempt>
            </div>
          ))}
      </ul>
    </div>
  );
};

export default LoginAttemptList;
