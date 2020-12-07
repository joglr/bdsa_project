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
  return result !== null ? result.map((e: Employer) => e) : [];
}

export function useStudents(): Student[] {
  const result = useAPI(["student"]);
  return result !== null ? result.map((s: Student) => s) : [];
}

export function usePlacements(): Placement[] {
  const result = useAPI(["placement"]);
  return result !== null ? result.map((p: Placement) => p) : [];
}

export function usePlacement(
  placementID: number | null
): (Placement & { students: Student[] }) | null {
  const result = useAPI(["placement", placementID]);
  return result !== null
    ? (result as Placement & { students: Student[] })
    : null;
}

export function useCapabilities(): Capability[] {
  const result = useAPI(["capability"]);
  return result !== null ? result.map((c: Capability) => c) : [];
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
