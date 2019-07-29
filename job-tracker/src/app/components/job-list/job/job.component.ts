import { Component, OnInit } from '@angular/core';
import { JobService } from '../../../services/job.service';

@Component({
  selector: 'job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})
export class JobComponent implements OnInit {

  constructor(private service: JobService) { }

  clients = [
    { id: 1, value: 'Client 1'},
    { id: 2, value: 'Client 2'},
    { id: 3, value: 'Client 3'}
  ];

  ngOnInit() {
  }

  onClear() {
    this.service.form.reset();
    this.service.initializeFormGroup();
  }

}
