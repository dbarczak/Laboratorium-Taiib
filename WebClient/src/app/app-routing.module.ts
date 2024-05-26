import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { ProductAddComponent } from './product-add/product-add.component';

const routes: Routes = [
  {path: 'products', component: ProductsComponent},
  {path: 'orders', component: OrdersComponent},
  {path: 'orders/all', component: OrdersComponent},
  {path: 'basket', component: BasketComponent},
  {path: 'products/add', component: ProductAddComponent},
  {path: 'products/:id', component: ProductDetailComponent},
  {path: 'orders/:orderId', component: OrderDetailComponent},
  {path: 'orders/all/:orderId', component: OrderDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
