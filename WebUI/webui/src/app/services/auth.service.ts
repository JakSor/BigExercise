import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { getInterpolationArgsLength } from '@angular/compiler/src/render3/view/util';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

 
  constructor(private http:HttpClient, private jwtHelper: JwtHelperService, private router: Router) { }
  registerUser(user:any)
  {
    return this.http.post<any>(`${environment.apiUrl}Account/register`, user);
  }
  loginUser(user:any)
  {
    return this.http.post<any>(`${environment.apiUrl}Account/login`, user);
  }
  loggedIn(){
   
    const token = this.getToken();
    if( token !== null &&  !this.jwtHelper.isTokenExpired(token))
    {
      return true;
    }
    this.router.navigate(["login"]);
    return false;
  }
  getToken()
  {
    return localStorage.getItem("jwt");
  }
}
