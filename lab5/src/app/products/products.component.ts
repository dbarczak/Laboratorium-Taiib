import { Component } from '@angular/core';
import { ProductResponseDTO } from '../models/product.interface';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css',
})
export class ProductsComponent {
  public data: ProductResponseDTO[] = [];

  constructor(private productsService: ProductsService) {
    this.getProducts();
  }


  private getProducts(): void{
    this.productsService.getProducts().subscribe({
      next: (res) => {
        console.log(res);
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: ()=>console.log('complete'),
    });
  }
}
