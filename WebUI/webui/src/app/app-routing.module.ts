import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddUserComponent } from './users/add-user/add-user.component';
import { DeleteUserComponent } from './users/delete-user/delete-user.component';
import { EditUserComponent } from './users/edit-user/edit-user.component';
import { ViewUserComponent } from './users/view-user/view-user.component';
import { ListUsersComponent } from './users/list-users/list-users.component';

import { ViewProductComponent } from './products/view-product/view-product.component';
import { AddProductComponent } from './products/add-product/add-product.component';
import { ListProductsComponent } from './products/list-products/list-products.component';
import { EditProductComponent } from './products/edit-product/edit-product.component';
import { DeleteProductComponent } from './products/delete-product/delete-product.component';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [

{
  path:'users',
  children:[
    {path:'', component:ListUsersComponent ,canActivate: [AuthGuard]},
    {path:'delete/:id', component:DeleteUserComponent,canActivate: [AuthGuard]},
    {path:'view/:id', component:ViewUserComponent,canActivate: [AuthGuard]},
    {path:'edit/:id', component: EditUserComponent,canActivate: [AuthGuard]},
    {path:'add', component: AddUserComponent,canActivate: [AuthGuard]}
  ]},
  {
    path:'products',
    children:[
      {path:'', component:ListProductsComponent},
      {path:'delete/:id', component:DeleteProductComponent, canActivate: [AuthGuard]},
      {path:'view/:id', component:ViewProductComponent},
      {path:'edit/:id', component: EditProductComponent,canActivate: [AuthGuard]},
      {path:'add', component: AddProductComponent, canActivate: [AuthGuard]}
    ]},
    {
      path: 'login',
      component: LoginComponent
    }
  ]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents=[

  ListProductsComponent,
  ListUsersComponent,
  AddUserComponent,
  AddProductComponent,
  EditProductComponent,
  EditUserComponent,
  DeleteProductComponent,
  DeleteUserComponent,
  ViewProductComponent,
  ViewUserComponent,
  LoginComponent
]