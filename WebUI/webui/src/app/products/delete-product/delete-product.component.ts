import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {
  productId: string;
  constructor(private _route:ActivatedRoute, private _productsService:ProductsService, private _snackbar:MatSnackBar, private _router:Router) { }

  ngOnInit(): void {
    this._route.params.subscribe(
      data => {
        this.productId = data.id;
      })
      if(this.productId)
      {
          this._productsService.deleteProduct(this.productId).subscribe(
            data => {
              this._snackbar.open("Product succesfully deleted.",'x',{duration:2500});
              this._router.navigateByUrl('/products') 
            } ,
            err=>{
              this._snackbar.open("Unable to delete product.",'x',{duration:2500});
              this._router.navigateByUrl('/products') 
            }           
          )
      }
  }

}
