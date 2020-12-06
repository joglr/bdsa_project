import { Capability } from "./Capability";
import { Placement } from "./Placement";

export interface Student {
  id: number;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  capabilities: Capability[];
  placements: Placement[];
}
