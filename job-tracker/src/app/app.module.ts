import { NgModule } from '@angular/core';

// Modules
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatListModule } from '@angular/material';

// Components
import { AppComponent } from './app.component';
import { JobsComponent } from './components/jobs/jobs.component';
import { JobItemComponent } from './components/job-item/job-item.component';


@NgModule({
  declarations: [
    AppComponent,
    JobsComponent,
    JobItemComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule, MatCheckboxModule, MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
