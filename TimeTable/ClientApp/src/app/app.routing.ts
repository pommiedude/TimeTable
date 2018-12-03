import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ListScheduleComponent } from './schedule/list-schedule/list-schedule.component';
import { AddScheduleComponent } from './schedule/add-schedule/add-schedule.component';

import { LoginFormComponent } from './account/login/login-form.component';

import { AuthGuard } from './../_guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginFormComponent,
    data: { title: 'Login Page' }
  },
  {
    path: 'list-schedule',
    component: ListScheduleComponent,
    data: { title: 'List Schedule' }
  },
  {
    path: 'add-schedule',
    component: AddScheduleComponent,
    data: { title: 'Add Schedule' }
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
