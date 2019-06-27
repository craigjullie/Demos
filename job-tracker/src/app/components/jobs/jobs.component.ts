import { Component, OnInit } from '@angular/core';
import { Job } from '../../models/job';

@Component({
  selector: 'jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {

  jobs:Job[];
  displayedColumns: string[] = ['id', 'title'];

  constructor() { }

  ngOnInit() {
    this.jobs = [
      { id:1,
        title: 'Job 1' 
      },
      { id:2,
        title: 'Job 2' 
      },
      { id:3,
        title: 'Job 3' 
      },
    ]
  }

}
