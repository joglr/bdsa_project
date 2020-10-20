# React workshop

## How to make a react app with JSX (easy )
```pwsh
npm create react-app --template typescript <appName>
```

## JSX Transpilation

```typescriptreact

function Button(props) {
  // props.title: "This button does nothing"
  return <div></div>
}

function Icon(props) {

  // props.icon: "sun"

  return <div></div>
}

function CoolButton() {
  return (
    <div>
      <Icon icon="sun" />
      <Button title="This button does nothing">Hello, click me!</Button>
    </div>
  )
}
```

...gets transpiled to:

```typescript
function CoolButton() {
  return React.createElement('div', 
    [
      React.createElement(Icon, null, {
        icon: 'sun'
      })
      React.createElement('button', 'Hello click me!', {
        title: 'This button has been pressed x times'
      })
    ]
  )
} 
```



```typescriptreact
ReactDOM.render(
  <CoolButton />,
  document.getElementById("app")
)
```

```html
<body>
  <div id="app">
    <!--Button goes here-->
  </div>
</body>
```