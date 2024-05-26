import { Component, OnInit } from '@angular/core';
import { BasketPositionResponseDTO } from '../models/basket.interface';
import { Router } from '@angular/router';
import { BasketService } from '../basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  public pos: BasketPositionResponseDTO[] = [];
  public userId: number = 1;

  constructor(private basketService: BasketService, private router: Router) {}

  ngOnInit(): void {
    this.getBasket();
  }

  private getBasket(): void {
    if (this.userId) {
      this.basketService.getUserBasket(this.userId).subscribe({
        next: (pos) => {
          this.pos = pos;
        },
        error: (err) => console.error(err)
      });
    }
  }

  public changeAmount(id: number, amount: number): void {
    this.basketService.changeAmount(id, amount).subscribe({
      next: () => this.getBasket(),
      error: (err) => console.error(err)
    });
  }

  public removeFromBasket(id: number): void {
    this.basketService.removeFromBasket(id).subscribe({
      next: () => this.getBasket(),
      error: (err) => console.error(err)
    });
  }

  public createOrder(): void {
    this.basketService.createOrder(this.userId).subscribe({
      next: () => this.getBasket(),
      error: (err) => console.error(err)
    });
  }
}
