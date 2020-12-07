import { Employer } from "./Employer";
import { Student } from "./Student";

export default interface User {
  id: number;
  name: string;
  person: Student | Employer;
}
