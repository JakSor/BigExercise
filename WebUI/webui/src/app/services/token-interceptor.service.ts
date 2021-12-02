import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class TokenInterceptorService  implements HttpInterceptor{

  constructor(private auth:AuthService) { }
  intercept(request:HttpRequest<any>, next: HttpHandler){
     
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.auth.getToken()}`
      }
    });
    request.headers.set('Content-Type','application/json');
    return next.handle(request);
  }
}
