import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import {HttpClientModule, HttpInterceptor, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AuthService } from './services/auth.service';
import {JwtModule} from '@auth0/angular-jwt'
import { ProductsService } from './services/products.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSidenavModule} from '@angular/material/sidenav';
import { LayoutModule } from './layout/layout.module';
import { ProductsModule } from './products/products.module';
import { UsersModule } from './users/users.module';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';


export function tokenGetter(){
  return localStorage.getItem("jwt")
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, 
    LayoutModule,
    MatSidenavModule,
    ProductsModule,
    UsersModule,
    RouterModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes:[]
      }
    })

  ],
  providers: [AuthService, ProductsService, AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    }
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
