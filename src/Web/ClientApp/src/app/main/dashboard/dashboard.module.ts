import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { dashboardRoutes } from './dashboard.routes';
import { JwtModule } from '@auth0/angular-jwt';
import { MessagesComponent } from './messages/messages.component';
import { HomeComponent } from './home/home.component';
import { SettingsComponent } from './settings/settings.component';
import { MessageComponent } from './messages/message/message.component';
import { ProfileComponent } from './profile/profile.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    HomeComponent,
    MessagesComponent,
    SettingsComponent,
    MessageComponent,
    ProfileComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(dashboardRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost'],
        blacklistedRoutes: ['']
      }
    })
  ],
  providers: []
})
export class DashboardModule { }
