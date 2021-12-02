import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  

  constructor(private http: HttpClient) { }

  getProducts(parameters:any)
  {
    return this.http.get<any>(`${environment.apiUrl}Product/GetAllProducts`, parameters)
      
  }
  
  getProductById(id : any)
  {
    return this.http.get<any>(`${environment.apiUrl}Product/GetProductDetails?id=${id}`);
  }
  addProduct(product:any)
  {
    return this.http.post(`${environment.apiUrl}Product/CreateProduct`, product);
  }
  updateProduct(product:any)
  {
    return this.http.put(`${environment.apiUrl}Product/UpdateProduct`, product);
  }
  deleteProduct(id:any)
  {
    return this.http.delete(`${environment.apiUrl}Product/DeleteProduct?id=${id}`);
  }

  getCountProducts()
  {
    return this.http.get<any>(`${environment.apiUrl}Product/Getroducts`);
  }
}
