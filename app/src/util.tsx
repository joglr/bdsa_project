import { useEffect, useState } from "react";

type Result = [] | null;

export function useFetch(path: string, options: any) {
  const [result, setResult] = useState<Result>(null);

  let isCanceled = false;

  async function getResult() {
    try {
      const response = await fetch(path, options).then((r) => r.json());
      if (!isCanceled) setResult(response);
    } catch (e) {
      if (!isCanceled) setResult([]);
    }
  }

  useEffect(() => {
    getResult();
    return () => {
      isCanceled = true;
    };
  }, []);
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
