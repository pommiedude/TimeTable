export class ScheduleLookupModel {
  scheduleId: number;
  name: string;
  date: Date;
}

export class ScheduleListViewModel {
  public schedules?: ScheduleLookupModel[] | undefined;

  constructor(data?: ScheduleListViewModel) {
      // if (data) {
      //     for (var property in data) {
      //         if (data.hasOwnProperty(property))
      //             (<any>this)[property] = (<any>data)[property];
      //     }
      // }
  }

}