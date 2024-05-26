import { Component, inject } from '@angular/core';
import { ProductRequestDTO } from '../models/product_request.interface';
import { ProductsService } from '../products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.css'
})
export class ProductAddComponent {
  constructor(private productService: ProductsService, private router: Router) {}

  public productRequest: ProductRequestDTO = {
    name: '',
    price: 0,
    image: null,
    isActive: true
  };

  public onSubmit(): void {
    this.productService.addProduct(this.productRequest).subscribe({
      next: () => this.router.navigate(['/products']),
      error: (err) => console.error(err)
    });
  }

  public cancel(): void{
        this.productRequest = {
          name: '',
          price: 0,
          image: null,
          isActive: true
        };

  }
}
