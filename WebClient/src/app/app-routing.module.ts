import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { AuthGuard } from './auth.guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'products', component: ProductsComponent, canActivate: [AuthGuard]},
  {path: 'orders', component: OrdersComponent, canActivate: [AuthGuard]},
  {path: 'orders/all', component: OrdersComponent, canActivate: [AuthGuard]},
  {path: 'basket', component: BasketComponent, canActivate: [AuthGuard]},
  {path: 'products/add', component: ProductAddComponent, canActivate: [AuthGuard]},
  {path: 'products/:id', component: ProductDetailComponent, canActivate: [AuthGuard]},
  {path: 'orders/:orderId', component: OrderDetailComponent, canActivate: [AuthGuard]},
  {path: 'orders/all/:orderId', component: OrderDetailComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
