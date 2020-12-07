import { DependencyList } from "react";
import { API_ROOT } from "./CONFIG";
import { Capability } from "./entities/Capability";
import { Employer } from "./entities/Employer";
import { Placement } from "./entities/Placement";
import { Student } from "./entities/Student";
import { useFetch } from "./util";

function useAPI(path: any[], options: any = {}, deps: DependencyList = []) {
  return useFetch([API_ROOT, ...path].join("/"), options, deps);
}

export function useEmployers(): Employer[] {
  const result = useAPI(["employer"]);
  return result !== null ? result.map<Employer>((e: Employer) => e) : [];
}

export function useStudents(): Student[] {
  const result = useAPI(["student"]);
  return result !== null ? result.map<Student>((s: Student) => s) : [];
}

export function usePlacements(): Placement[] {
  const result = useAPI(["placement"]);
  return result !== null ? result.map<Placement>((p: Placement) => p) : [];
}

export function useCapabilities(): Capability[] {
  const result = useAPI(["capability"]);
  return result !== null ? result.map<Capability>((c: Capability) => c) : [];
}

export async function apply(userID: number, placementID: number) {
  const student = await fetch(
    [API_ROOT, "student", userID].join("/")
  ).then((r) => r.json());
  // const { id, ...student } = students.find((s: Student) => s.id === userID);

  await fetch([API_ROOT, "student", userID].join("/"), {
    method: "put",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify({
      ...student,
      capabilities: student.capabilities.map((c: Capability) => c.id),
      placements: [...student.placements, placementID],
    }),
  });
}
