import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../products.service';
import { ProductResponseDTO } from '../models/product.interface';
import { ProductRequestDTO } from '../models/product_request.interface';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent {
  public product!: ProductResponseDTO;
  public productRequest: ProductRequestDTO = { name: '', price: 0, image: null, isActive: true };

  constructor(
    private route: ActivatedRoute,
    private productService: ProductsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.productService.getProductById(+id).subscribe({
        next: (product) => {
          this.product = product;
          this.productRequest = { ...product };
        },
        error: (err) => console.error(err)
      });
    }
  }

  public onSubmit(action: string): void {
    if (!this.product) return;

    switch (action) {
      case 'delete':
        this.productService.deleteProduct(this.product.id).subscribe({
          next: () => this.router.navigate(['/products']),
          error: (err) => console.error(err)
        });
        break;
      case 'changeState':
        this.productService.activateProduct(this.product.id).subscribe({
          next: () => this.reloadComponent(),
          error: (err) => console.error(err)
        });
        break;
      case 'save':
        this.productService.updateProduct(this.product.id, this.productRequest).subscribe({
          next: () => this.reloadComponent(),
          error: (err) => console.error(err)
        });
        break;
    }
  }

  private reloadComponent(): void {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/products/${this.product.id}`]);
    });
  }

  public cancel(): void {
    this.router.navigate(['/products']);
  }
}
