import { Placement } from "./Placement";

export interface Employer {
  id: number;
  companyName: string;
  companyDescription: string;
  companyImage: string;
  placements: Placement[];
}
