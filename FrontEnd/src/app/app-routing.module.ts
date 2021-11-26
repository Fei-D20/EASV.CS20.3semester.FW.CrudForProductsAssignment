import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'products',
    loadChildren: () =>
      import('./products/products.module')
        .then(f => f.ProductsModule)
  },

  { path: 'auth',
    loadChildren: () =>
      import('./auth/auth.module')
        .then(f => f.AuthModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
