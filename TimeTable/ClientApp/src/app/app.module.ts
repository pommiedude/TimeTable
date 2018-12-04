import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { StoreModule } from '@ngrx/store';

import { ScheduleService } from '../_services/schedule-service';
import { AppRoutingModule } from './app.routing';

import { HomeComponent } from './home/home.component';
import { ListScheduleComponent } from './schedule/list-schedule/list-schedule.component';
import { AddScheduleComponent } from './schedule/add-schedule/add-schedule.component';
import { LoginFormComponent } from './account/login/login-form.component';

import { reducer } from './../_state/reducers/schedule.reducer';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ListScheduleComponent,
    AddScheduleComponent,
    LoginFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    StoreModule.forRoot({
      schedule: reducer
    }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [ScheduleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
