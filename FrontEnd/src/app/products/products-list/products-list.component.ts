import { Component, OnInit } from '@angular/core';
import {ProductsService} from "../shared/products.service";
import {ProductDto} from "../shared/product.dto";

@Component({
  selector: 'app-EASV-CS20-FW-Assignment-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {
   products: ProductDto[] | undefined;

  constructor(private _productService: ProductsService) { }

  ngOnInit(): void {
    this._productService.getAll()
      .subscribe(products =>{
        this.products = products;
      });
  }

}
