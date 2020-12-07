import { USER_TYPE } from "../store";
import { Employer } from "./Employer";
import { Student } from "./Student";

export default interface User {
  id: number;
  name: string;
  person: Student | Employer;
  userType: USER_TYPE;
}
