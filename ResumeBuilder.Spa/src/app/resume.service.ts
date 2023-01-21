import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactInfo } from './models/contact-info.model';
import { Resume } from './models/resume.model';

@Injectable({
  providedIn: 'root'
})
export class ResumeService {
  baseUrl: string = '';

  constructor(
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) {
    baseUrl = baseUrl;
    console.log(baseUrl);
  }

  getContacts(): Observable<ContactInfo[]> {
    const url = `${this.baseUrl}/api/Contact/GetContacts`;
    const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.get<ContactInfo[]>(url, { headers });
  }

  getContact(contactId: number): Observable<ContactInfo> {
    const url = `${this.baseUrl}/api/Contact/GetContacts/${contactId}`;
    const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.get<ContactInfo>(url, { headers });
  }

  getResumes(): Observable<Resume[]> {
    const url = `${this.baseUrl}/api/Resume/GetResumes`;
    const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.get<Resume[]>(url, { headers });
  }

  getResume(resumeId: number): Observable<Resume> {
    const url = `${this.baseUrl}/api/Resume/GetResumes/${resumeId}`;
    const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.get<Resume>(url, { headers });

  }

  importResume(resume: Resume): Observable<{contactId: number, resumeId: number}> {
      const url = `${this.baseUrl}/api/Resume`;
      const headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.post<{ contactId: number, resumeId: number }>(url, resume, { headers });
  }


}
