import { Resume } from "./resume.model";

export interface ContactInfo {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  city: string;
  state: string;
  zip: string;
  phone: string;
}
