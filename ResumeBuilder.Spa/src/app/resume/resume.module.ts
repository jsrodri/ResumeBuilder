import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResumeRoutingModule } from './resume-routing.module';
import { ResumeComponent } from './resume.component';
import { SkillComponent } from './components/skill/skill.component';
import { ResumeService } from '../resume.service';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ContactInfoComponent } from './components/contact-info/contact-info.component';
import { CardModule } from 'primeng/card';
import { ProfessionalSummaryComponent } from './components/professional-summary/professional-summary.component';

@NgModule({
  declarations: [
    ResumeComponent,
    SkillComponent,
    ContactInfoComponent,
    ProfessionalSummaryComponent    
  ],
  imports: [
    CommonModule,
    ResumeRoutingModule,
    BreadcrumbModule,
    CardModule
  ],
  providers: [
    ResumeService
  ]

})
export class ResumeModule { }
