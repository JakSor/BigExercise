import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule, routingComponents } from '../app-routing.module';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS_FACTORY} from '@angular/material/snack-bar';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';


@NgModule({
  declarations: [
    routingComponents
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    RouterModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSnackBarModule,
    MatTableModule,
    MatPaginatorModule
    
  ],
  providers:[
    {
      provide: MAT_SNACK_BAR_DEFAULT_OPTIONS_FACTORY,useValue: {duration:2500}
    }
  ]
})
export class SharedModule { }
