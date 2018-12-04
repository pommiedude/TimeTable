import { Component, OnInit, Inject } from '@angular/core';
import { ScheduleLookupModel, ScheduleListViewModel } from './../../../_models/index';
import { ScheduleService } from './../../../_services/schedule-service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { AppState } from '../../../_state/app.state';

import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'list-schedule-list',
  templateUrl: './list-schedule.component.html'
})
export class ListScheduleComponent implements OnInit {

  schedules: Observable<ScheduleLookupModel[]>;

  public vm: ScheduleListViewModel;
  private hubConnection: HubConnection;

  constructor(
    private router: Router,
    @Inject('BASE_URL') baseUrl: string,
    private _scheduleService: ScheduleService,
    private store: Store<AppState>) {
  }

  ngOnInit(): void {
    // TODO : Switch over to use state store!
    // this.schedules = this.store.select('schedule');
     this._scheduleService.getSchedules().subscribe(result => {
       this.vm = result;
     }, error => console.error(error));
  }

  delete(schedule: ScheduleLookupModel): void {
    this._scheduleService.delete(schedule.scheduleId)
       .subscribe(data => {
         this.vm.schedules = this.vm.schedules.filter(u => u !== schedule);
       });
  }

  add(): void {
    this.router.navigate(['add-schedule']);
  }
}
