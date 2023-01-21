import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { Resume } from '../models/resume.model';
import { ResumeService } from '../resume.service';

@Component({
  selector: 'app-resume',
  templateUrl: './resume.component.html',
  styleUrls: ['./resume.component.css']
})
export class ResumeComponent implements OnInit {
  breadcrumbItems: MenuItem[] = [];
  breadcrumbHome: MenuItem = {};
  resume: Resume = <Resume>{};

  constructor(private resumeService: ResumeService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let resumeId = this.route.snapshot.params['resumeId'];
    this.resumeService.getResume(resumeId).subscribe(resume => {
      console.log('test', resume);
      this.resume = resume;

      this.resume.importDateTime = new Date(this.resume.importDateTime);

      this.breadcrumbItems = [
        { label: `Resumes`, routerLink: ['/resumes'] },
        { label: `${this.resume.contact?.firstName} ${this.resume.contact?.lastName} - ${this.resume.importDateTime.toDateString()}` },
      ];

      this.breadcrumbHome = { icon: 'pi pi-home', routerLink: '/' }
    });

    console.log(this.resume);
  }

}
