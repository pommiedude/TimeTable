import { Action } from '@ngrx/store';
import { ScheduleLookupModel } from '../../_models';

export const CREATE_SCHEDULE = 'Schedule_Create';
export const DELETE_SCHEDULE = 'Schedule_Delete';

export class CreateSchedule implements Action {
    readonly type = CREATE_SCHEDULE;
    constructor(public payload: ScheduleLookupModel) { }
}

export class DeleteSchedule implements Action {
    readonly type = DELETE_SCHEDULE;
    constructor(public scheduleId: number) { }
}

export type Actions = CreateSchedule | DeleteSchedule;
