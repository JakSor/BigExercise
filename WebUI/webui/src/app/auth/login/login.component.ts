import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean;
  constructor(private _router:Router, private _authService: AuthService) { }
  ngOnInit(): void {
  }

  login(form:NgForm){
    const credentials = {
      'username' : form.value.username,
      'password' : form.value.password
    }
    this._authService.loginUser(credentials)
          .subscribe(
            res => {
              const token = (<any> res).token;
              localStorage.setItem("jwt", token);
              this.invalidLogin = false;
              this._router.navigate(["/products"]);
            },
            err => {
              this.invalidLogin = true;
            }
          )
  }
}
