import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobListComponent } from './components/job-list/job-list.component';
import { AboutComponent } from './components/pages/about/about.component';
import { JobComponent } from './components/job-list/job/job.component';

const routes: Routes = [
  { path: '', component: JobListComponent },
  { path: 'about', component: AboutComponent },
  { path: 'job', component: JobComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }