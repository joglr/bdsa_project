import React from 'react';
import logo from './logo.svg';
import './App.css';
import './mycss.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React

        </a>
      </header>
      <a>
      <MyButton text1="hej" text2="hihihi"/>
      <MyButton text1="bruhh" text2="hohoho"/>
      </a>
    </div>
  );
}

function MyButton({text1: hejhejhejehejdenergodfin, text2}: {text1: string, text2: string}) {

  // const {text1, text2} = props;
  const [epicJson, setEpicJson] = React.useState(null);


  const [shouldShowSentence1,setShouldShowSentence1] = React.useState(false);
  React.useEffect(() => {
    console.log(shouldShowSentence1);
    fetch('https://jsonplaceholder.typicode.com/todos/1')
    .then(response => response.json())
    .then(json => setEpicJson(json));
    console.log("jeg gjorde det far");
  }, [shouldShowSentence1]);

  function changeBoolean() {
    setShouldShowSentence1(!shouldShowSentence1);
  }
  // let input = hejhejhejehejdenergodfin + " " + text2;
  return <button onClick={changeBoolean}>
    {shouldShowSentence1 ? "text1😊" : "text2😎"}
    {shouldShowSentence1 ? hejhejhejehejdenergodfin : text2}
    {JSON.stringify(epicJson)}
  </button>
}

export default App;
