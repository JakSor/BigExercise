import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {

  product:any;
  productId:string;
  constructor(private _productsService: ProductsService, private _route:ActivatedRoute) { }

  ngOnInit(): void {
  this._route.params.subscribe(data=> {
    this.productId = data.id;
  });
  this._productsService.getProductById(this.productId).subscribe(
    data => this.product = data
    
  );
  
  }

}
