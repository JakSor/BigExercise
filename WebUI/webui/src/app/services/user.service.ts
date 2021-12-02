import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  
  constructor(private http: HttpClient) { }

  listUsers()
  {
    return this.http.get(`${environment.apiUrl}Product/GetAllProducts`)
  }
  
  getProductById(id : any)
  {
    return this.http.get(`${environment.apiUrl}Product/GetProductDetails?id=${id}`)
  }

}
