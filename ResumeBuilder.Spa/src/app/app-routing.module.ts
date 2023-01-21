import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'resumes', pathMatch: 'full' },
  { path: 'resumes', loadChildren: () => import('./resumes/resumes.module').then(m => m.ResumesModule) },
  { path: 'resumes/:resumeId', loadChildren: () => import('./resume/resume.module').then(m => m.ResumeModule) },
  
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
