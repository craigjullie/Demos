import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTable } from '@angular/material';
import { JobListDataSource, JobListItem } from './job-list-datasource';

@Component({
  selector: 'job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  @ViewChild(MatTable, {static: false}) table: MatTable<JobListItem>;
  dataSource: JobListDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', 'desc'];
  showView: string = 'job-list';

  ngOnInit() {
    this.dataSource = new JobListDataSource();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  showJob(row) {
    console.log(row);
    this.showView = "job";
  }

  showJobList() {
    this.showView = "job-list";
  }
}
