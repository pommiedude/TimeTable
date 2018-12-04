import { ScheduleLookupModel } from '../../_models';
import { Actions, CREATE_SCHEDULE, DELETE_SCHEDULE } from '../actions/schedule.actions';

const initialState: ScheduleLookupModel = {
    scheduleId: 1,
    name: 'Test Schedule',
    date: new Date()
};

export function reducer(
    state: ScheduleLookupModel[] = [],
    action: Actions) {

    switch (action.type) {
        case CREATE_SCHEDULE:
            return [...state, action.payload];

        case DELETE_SCHEDULE:
            return state.filter(({ scheduleId }) => scheduleId !== action.scheduleId);

        default:
            return state;
    }
}
