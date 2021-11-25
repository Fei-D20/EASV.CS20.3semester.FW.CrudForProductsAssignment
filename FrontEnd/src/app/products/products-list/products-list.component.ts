import {Component, OnDestroy, OnInit} from '@angular/core';
import {ProductsService} from "../shared/products.service";
import {ProductDto} from "../shared/product.dto";
import {Observable, Subscription} from "rxjs";
import {catchError, delay, take} from "rxjs/operators";

@Component({
  selector: 'app-EASV-CS20-FW-Assignment-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})


export class ProductsListComponent implements OnInit{
  // products: ProductDto[] | undefined;
  products$: Observable<ProductDto[]> | undefined;
  // remove the private for html file can use this field
  error: any;

  constructor(private _productService: ProductsService) { }

  ngOnInit(): void {
    // this._productService.getAll()
    //   // a pipe get into observable and do something.
    //   // we can say how many times we want get data from observable,
    //   // and then stop listening.
    //   // in this case is take 1 times reply and then stop.
    //   .pipe(
    //     take(1)
    //   )
    //   .subscribe(products => {
    //     this.products = products;
    //   });
    this.products$ =
      this._productService
        .getAll()
        // this pipe is for test the loading screen. and let the system delay 1 sec to show loading.
        .pipe(
          delay(1000)
        )
        // use pipe to catch up the errors
        .pipe(
          catchError(err => {
            this.error = err;
            throw err;
          })
        )
  }
}

// // Oninit and OnDestroy is be called life hook. to control the component lifetime
// export class ProductsListComponent implements OnInit, OnDestroy {
//   products: ProductDto[] | undefined;
//
//   // this field is working for make sure the httpClient unsubscribe the require.
//   private productSubscribe: Subscription | undefined;
//
//   constructor(private _productService: ProductsService) { }
//
//   ngOnInit(): void {
//     this.productSubscribe = this._productService.getAll()
//       .subscribe(products => {
//         this.products = products;
//       });
//   }
//
//   ngOnDestroy(): void {
//     if(this.productSubscribe){
//       this.productSubscribe.unsubscribe();
//     }
//   }
// }


