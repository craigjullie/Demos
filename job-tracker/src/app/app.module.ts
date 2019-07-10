import { NgModule } from '@angular/core';

// Modules
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatListModule, MatPaginatorModule, MatSortModule } from '@angular/material';
import { MatTableModule } from '@angular/material/table';


// Components
import { AppComponent } from './app.component';
import { JobListComponent } from './components/job-list/job-list.component';


@NgModule({
  declarations: [
    AppComponent,
    JobListComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule, MatCheckboxModule, MatTableModule, MatPaginatorModule, MatSortModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
