import { API_ROOT } from "./CONFIG";
import { Capability } from "./Entities/Capability";
import { Employer } from "./Entities/Employer";
import { Placement } from "./Entities/Placement";
import { Student } from "./Entities/Student";
import { useFetch } from "./util";

function useAPI(path: String[], options: any = {}) {
  return useFetch([API_ROOT, ...path].join("/"), options);
}

export function useEmployers(): Employer[] {
  const result = useAPI(["employer"]);
  return result !== null
    ? result.map<Employer>(
        ({ id, companyName, companyDescription, companyImage }) => ({
          id,
          companyName,
          companyDescription,
          companyImage,
        })
      )
    : [];
}

export function useStudents(): Student[] {
  const result = useAPI(["student"]);
  return result !== null
    ? result.map<Student>(
        ({ id, firstName, lastName, phoneNumber, email, capabilities }) => ({
          id,
          firstName,
          lastName,
          phoneNumber,
          email,
          capabilities,
        })
      )
    : [];
}

export function usePlacements(): Placement[] {
  const result = useAPI(["placement"]);
  return result !== null
    ? result.map<Placement>(
        ({
          id,
          title,
          employer: {
            id: employerId,
            companyName,
            companyDescription,
            companyImage,
          },
          placementImage,
          description,
          location,
          minHours,
          maxHours,
          capabilities,
          students,
        }) => ({
          id,
          title,
          employer: {
            id: employerId,
            companyName,
            companyDescription,
            companyImage,
          },
          placementImage,
          description,
          location,
          minHours,
          maxHours,
          capabilities,
          students,
        })
      )
    : [];
}

export function useCapabilities(): Capability[] {
  const result = useAPI(["capability"]);
  return result !== null
    ? result.map<Capability>(
        ({ id, name, description, students, placements }) => ({
          id,
          name,
          description,
          students,
          placements,
        })
      )
    : [];
}
