import { Capability } from "./Capability";
import { Placement } from "./Placement";
import User from "./User";

export interface Student extends User {
  id: number;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  capabilities: Capability[];
  placements: Placement[];
}
