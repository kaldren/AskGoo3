import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main/main.component';
import { SignInComponent } from './main/signin/signin.component';
import { MessagesComponent } from './main/dashboard/messages/messages.component';

const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'signin', component: SignInComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
