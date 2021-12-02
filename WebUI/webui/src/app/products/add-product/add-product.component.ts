import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  addProductForm: FormGroup = new FormGroup({});
  constructor(private _formBuilder:FormBuilder, private _productService:ProductsService, private _snackbar: MatSnackBar, private _router: Router ) { }

  ngOnInit(): void {
    this.addProductForm = this._formBuilder.group({
      'name': new FormControl(''),
      'description': new FormControl(''),
      'isFood' : new FormControl(true),
      'price' : new FormControl(0),
      'amountInStock': new FormControl(15),
       
      'size': new FormControl(''),
      'color': new FormControl('string'),
      'isDrink': new FormControl(true),
      'expireDate':new FormControl(new Date()),
      'quantityInPackage': new FormControl(0)


    })
  }
    addProduct()
    {
      this._productService.addProduct(this.addProductForm.value).subscribe(
        data => {this._snackbar.open("Product created successfully",'x',{duration:2500});
        this._router.navigateByUrl('/products') },
        err=> this._snackbar.open("Unable to create Product!",'x',{duration:2500})
        
        //405 => object wordt nog niet herkend als ProductDTO => interface aanmaken, lege values instantiëren waar nodig //fixed 
      );
     
    }
  }


