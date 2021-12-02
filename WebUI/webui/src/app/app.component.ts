import { Route } from '@angular/compiler/src/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Exercise';
constructor(private router : Router, private jwtHelper: JwtHelperService) {

}
IsUserAuthenticated()
{
  const token: string | null = localStorage.getItem("jwt");
  if (token !== null && !this.jwtHelper.isTokenExpired(token))
  {
    return true;
  }
  else
  {
    return false;
  }

}
logOut()
{
  localStorage.removeItem("jwt");
}
}
