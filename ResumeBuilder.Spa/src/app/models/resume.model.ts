import { ContactInfo } from "./contact-info.model";
import { Skill } from "./skill.model";

export interface Resume {
  id: number;
  importDateTime: Date;
  professionalSummary: string;
  contact: ContactInfo;
  skills: Skill[];
}
