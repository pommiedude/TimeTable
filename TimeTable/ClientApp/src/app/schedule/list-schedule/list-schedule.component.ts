import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ScheduleLookupModel, ScheduleListViewModel } from './../../../_models/index';
import { ScheduleService } from './../../../_services/schedule-service';
import { Router } from '@angular/router';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'list-schedule-list',
  templateUrl: './list-schedule.component.html'
})
export class ListScheduleComponent implements OnInit {
  public vm: ScheduleListViewModel;
  private hubConnection: HubConnection;

  constructor(
    private router: Router,
    @Inject('BASE_URL') baseUrl: string,
    private _scheduleService: ScheduleService) {
  }

  ngOnInit(): void {
    this._scheduleService.getSchedules().subscribe(result => {
      this.vm = result;
    }, error => console.error(error));

    this.hubConnection = new HubConnectionBuilder().withUrl('http://localhost:5000/schedules').build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

      this.hubConnection.on('updatedSchedule', (name: string, message: string) => {
        // TODO: Update this.vm.schedules variable with the schedules received, or if
        // smaller transaction are used delete, add single components etc...
      });
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
