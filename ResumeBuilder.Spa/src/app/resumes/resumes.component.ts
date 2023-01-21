import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { Resume } from '../models/resume.model';
import { ResumeService } from '../resume.service';

@Component({
  selector: 'app-resumes',
  templateUrl: './resumes.component.html',
  styleUrls: ['./resumes.component.css']
})
export class ResumesComponent implements OnInit {
  breadcrumbItems: MenuItem[] = [];
  breadcrumbHome: MenuItem = {};
  uploadedResumes: Resume[] = [];

  constructor(private resumeService: ResumeService,
        private route: ActivatedRoute
  ) {
    this.breadcrumbItems = [
      { label: `Resumes`, routerLink: ['/resumes'] }
    ];

    this.breadcrumbHome = { icon: 'pi pi-home', routerLink: '/' }
  }

  ngOnInit(): void {
    this.loadResumes();
  }

  onUpload(event: any) {
    console.log(event);

    for (let i = 0; i < event.files.length; i++) {
      var file = event.files[i];
      file["contactId"] = event.originalEvent.body[i].contactId;
      file["resumeId"] = event.originalEvent.body[i].resumeId;

      this.loadResumes();
    }
  }

  loadResumes() {
    this.resumeService.getResumes().subscribe(resumes => {
      this.uploadedResumes = resumes
    });
  }

}
