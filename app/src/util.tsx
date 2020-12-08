import { useEffect, useState } from "react";

type Result = [] | null;

export function useFetch(
  path: string,
  options: any,
  deps: React.DependencyList = []
): any {
  const [result, setResult] = useState<Result>(null);

  useEffect(() => {
    async function getResult(isCanceled: boolean) {
      try {
        const response = await fetch(path, options).then((r) => r.json());
        if (!isCanceled) setResult(response);
      } catch (e) {
        if (!isCanceled) setResult([]);
      }
    }
    let isCanceled = false;
    getResult(isCanceled);
    return () => {
      isCanceled = true;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, deps);
  return result;
}

export function useInput(defaultValue = "") {
  const [value, setValue] = useState(defaultValue);
  function onChange(e: React.ChangeEvent<HTMLInputElement>) {
    setValue(e.target.value);
  }
  return { value, onChange };
}

export function sleep(amount: number) {
  return new Promise((resolve) => setTimeout(resolve, amount));
}

export function useLocalStorage<T>(key: string, initialValue: any): [T, any] {
  // State to store our value
  // Pass initial state function to useState so logic is only executed once
  const [storedValue, setStoredValue] = useState<T>(() => {
    try {
      // Get from local storage by key
      const item = window.localStorage.getItem(key);
      // Parse stored json or if none return initialValue
      return item ? JSON.parse(item) : initialValue;
    } catch (error) {
      // If error also return initialValue
      console.log(error);
      return initialValue;
    }
  });

  // Return a wrapped version of useState's setter function that ...
  // ... persists the new value to localStorage.
  const setValue = (value: T) => {
    try {
      // Allow value to be a function so we have same API as useState
      const valueToStore =
        value instanceof Function ? value(storedValue) : value;
      // Save state
      setStoredValue(valueToStore);
      // Save to local storage
      window.localStorage.setItem(key, JSON.stringify(valueToStore));
    } catch (error) {
      // A more advanced implementation would handle the error case
      console.log(error);
    }
  };

  return [storedValue, setValue];
}
