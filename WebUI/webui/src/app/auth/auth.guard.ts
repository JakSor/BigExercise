import { Injectable } from '@angular/core';
import {  CanActivate, Router} from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../services/auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService) {

}
  canActivate() : boolean {
    return this.authService.loggedIn();
  }
  
}
