import { Component, OnInit,AfterViewInit,ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { ProductsService } from 'src/app/services/products.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css']
})
export class ListProductsComponent implements OnInit {

  displayedColumns: string[] = ['name', 'isFood', 'description', 'price','edit', 'delete', 'buy'];
  apiData: any;
  tableProducts=new MatTableDataSource<Product>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  countProducts :number;
  parameters: Parameters = new Parameters();
  pageEvent: PageEvent;

  constructor(private _productsService:ProductsService) { }
  

  ngOnInit(): void {
    this._productsService.getProducts(this.parameters)
    .subscribe(
      
        res=>{
          this.apiData = res;
          this.tableProducts.data = this.apiData.productDTOs;
          console.log(this.tableProducts.data);
          this.countProducts = this.apiData.countProducts
        }  ,
      err => console.log(err)
    )
   
    
  }
  ngAfterViewInit(){
    
    this.tableProducts.paginator = this.paginator;
  }



  getProducts(event:PageEvent)
  { 
    this.parameters.pageNumber = (event.pageIndex+1);
    this.parameters.pageSize = event.pageSize;
    
    this._productsService.getProducts(this.parameters)
    .subscribe(
      
        res=>{
          this.apiData = res;
          this.tableProducts.data = this.tableProducts.data.concat(this.apiData.productDTOs);
          console.log(this.apiData);
        
        }  ,
      err => console.log(err)
    )
   this.countProducts = this.apiData.countProducts;
    }
    
}
export interface Product {
  name: string;
  isFood: boolean ;
  description: string;
  price: number;
}
export interface ProductApiData{
  countProducts : number;
  filter: string;
  productDTOs: Product[]

}
export class Parameters
{
  pageNumber: number = 1;
  pageSize: number = 9;
  inStock: boolean = false;
}