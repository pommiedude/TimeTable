import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ScheduleLookupModel, ScheduleListViewModel } from '../_models';

@Injectable()
export class ScheduleService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getSchedules(): Observable<ScheduleListViewModel> {
    return this.http.get<ScheduleListViewModel>(this.baseUrl + 'api/schedule');
  }

  getById(id: number): Observable<ScheduleLookupModel> {
    return this.http.get<ScheduleLookupModel>(this.baseUrl + 'api/schedule/' + id);
  }

  add(formdata: any) {
    return this.http.post(this.baseUrl + 'api/schedule/', formdata);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + 'api/schedule/' + id);
  }
}
