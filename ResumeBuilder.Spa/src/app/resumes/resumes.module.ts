import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResumesRoutingModule } from './resumes-routing.module';
import { ResumesComponent } from './resumes.component';
import { RouterModule } from '@angular/router';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { FileUploadModule } from 'primeng/fileupload';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';


@NgModule({
  declarations: [
    ResumesComponent
  ],
  imports: [
    CommonModule,
    ResumesRoutingModule,
    RouterModule,
    FileUploadModule,
    BreadcrumbModule,
    ButtonModule,
    TableModule
  ]
})
export class ResumesModule { }
