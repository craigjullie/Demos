import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor() { }

  form: FormGroup = new FormGroup({
    $key: new FormControl(null),
    jobName: new FormControl('', Validators.required),
    jobDescription: new FormControl('', Validators.required),
    client: new FormControl('', Validators.required)
  });

  initializeFormGroup() {
    this.form.setValue({
      $key: null,
      JobName: ''
    });
  }
  
}
