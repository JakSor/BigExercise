import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.css']
})
export class ListUsersComponent implements OnInit {

  listProducts  : any;
  constructor(private productservice: ProductsService) { }

  ngOnInit(): void {
    
  }

}
