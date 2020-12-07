import { Capability } from "./Capability";
import { Employer } from "./Employer";

export interface Placement {
  id: number;
  title: string;
  employer: Employer;
  placementImage: string;
  description: string;
  location: string;
  minHours: number;
  maxHours: number | null;
  capabilities: Capability[];
  students: number[];
}
