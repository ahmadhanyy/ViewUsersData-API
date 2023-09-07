import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { AddusersComponent } from './addusers/addusers.component';

const routes: Routes = [
  {path: "", component: UsersComponent},
  {path: "AddUser-Page", component: AddusersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const RoutingComponants = [UsersComponent, AddusersComponent];
