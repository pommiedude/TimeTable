import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ScheduleService } from './../../../_services/schedule-service';
import { Router } from "@angular/router";
import { AppCustomDirective } from './custom-validator';

@Component({
  selector: 'app-add-schedule',
  templateUrl: './add-schedule.component.html'
})

export class AddScheduleComponent implements OnInit {
  addForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder,private router: Router, private _scheduleService: ScheduleService) {
  }

  ngOnInit() {
    this.addForm = this.formBuilder.group({
      id: [],
      title: ['', [Validators.required, Validators.minLength(5)]],
      line: ['', [Validators.required, Validators.minLength(10)]],
      date: ['', [Validators.required, AppCustomDirective.validDate]]
    });
  }

  get f() { return this.addForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.addForm.invalid) {
      return;
    }
    this._scheduleService.add(this.addForm.value)
      .subscribe( data => {
        this.router.navigate(['list-schedule']);
      },
      error => {
        console.log("TODO : Handle errors" + JSON.stringify(error))
        }
      );
    }
}
