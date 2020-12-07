import { Placement } from "./Placement";
import User from "./User";

export interface Employer extends User {
  id: number;
  companyName: string;
  companyDescription: string;
  companyImage: string;
  placements: Placement[];
}
