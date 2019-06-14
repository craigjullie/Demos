import { Component, OnInit, Input} from '@angular/core';
import { Job } from 'src/app/models/Job';

@Component({
  selector: 'job-item',
  templateUrl: './job-item.component.html',
  styleUrls: ['./job-item.component.css']
})
export class JobItemComponent implements OnInit {
  @Input() job: Job;

  constructor() { }

  ngOnInit() {
  }

}
