export class ScheduleLookupModel {
  scheduleId: number;
  name: string;
  date: Date;
}

export class ScheduleListViewModel {
  public schedules?: ScheduleLookupModel[] | undefined;
  constructor() {
  }
}
