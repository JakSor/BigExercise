import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { routingComponents } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [routingComponents],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class AuthModule { }
