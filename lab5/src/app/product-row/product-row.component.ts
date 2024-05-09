import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductResponseDTO } from '../models/product.interface';

@Component({
  selector: '[app-product-row]',
  templateUrl: './product-row.component.html',
  styleUrl: './product-row.component.css'
})
export class ProductRowComponent {
  @Input('app-product-row') product!: ProductResponseDTO;
  @Output() choosed = new EventEmitter<ProductResponseDTO>();
  public onChooseClick(): void {
    this.choosed.emit(this.product);
  }
}
