import { Component, inject } from '@angular/core';
import { ProductResponseDTO } from '../models/product.interface';
import { ProductsService } from '../products.service';
import { Router } from '@angular/router';
import { BasketService } from '../basket.service';
import { BasketPositionRequestDTO } from '../models/basket-request.interface';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public data: ProductResponseDTO[] = [];
  public page: number = 0;
  public count: number = 10;
  public name: string = "";
  public sortBy: string = "";
  public isActive: boolean = true;
  public sortingAsc: boolean = false;

  private readonly basketService = inject(BasketService);

  public basketRequest: BasketPositionRequestDTO = {
    userID: 1,
    productID: 1,
    amount: 1
  };

  constructor(private productsService: ProductsService, private router: Router) {
    this.getData();
  }

  private getData(): void {
    this.productsService.getProducts({ count: this.count, page: this.page }, this.name, this.isActive, this.sortBy, this.sortingAsc).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  public getDataSorted(): void {
    this.getData();
  }

  public addNewProduct(): void{
    this.router.navigate(['/products/add']);
  }

  public addToBasket(id: number): void{
    this.basketRequest.productID = id;
    console.log(this.basketRequest);
    this.basketService.addToBasket(this.basketRequest).subscribe({
      next: (res) => {
        this.router.navigate(['/products']);
      },
      error: (err) => console.error(err)
    })
  }
}
