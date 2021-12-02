import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  productId:string ='';
  product:any;
  editProductForm: FormGroup = new FormGroup({})
  constructor(private route:ActivatedRoute,private formBuilder:FormBuilder, private _productService:ProductsService) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      data=> {this.productId = data.id});
    
      if(this.productId !== '')
      {
        this._productService.getProductById(this.productId)
        .toPromise()
        .then(data =>{
          this.product = data;
          console.log(this.product);
        })
        }
        this.editProductForm
  }
}