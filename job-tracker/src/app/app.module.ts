import { NgModule } from '@angular/core';

// Modules
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatPaginatorModule, MatSortModule,  MatToolbarModule, MatGridListModule } from '@angular/material';
import { MatFormFieldModule, MatInputModule, MatSelectModule } from '@angular/material';
import { MatTableModule } from '@angular/material/table';
import { ReactiveFormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';


// Components
import { AppComponent } from './app.component';
import { JobListComponent } from './components/job-list/job-list.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { AboutComponent } from './components/pages/about/about.component';
import { JobComponent } from './components/job-list/job/job.component';


@NgModule({
  declarations: [
    AppComponent,
    JobListComponent,
    HeaderComponent,
    AboutComponent,
    JobComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatButtonModule, 
    MatCheckboxModule, 
    MatTableModule, 
    MatPaginatorModule, 
    MatSortModule, 
    MatToolbarModule,
    MatSelectModule,
    MatGridListModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
