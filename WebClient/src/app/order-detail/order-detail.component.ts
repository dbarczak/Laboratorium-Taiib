import { Component } from '@angular/core';
import { OrderPositionResponseDTO } from '../models/order-position.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrl: './order-detail.component.css'
})
export class OrderDetailComponent {
  public pos: OrderPositionResponseDTO[] = [];

  constructor(private route: ActivatedRoute, private orderService: OrdersService) {}

  ngOnInit(): void {
    const orderId = this.route.snapshot.paramMap.get('orderId');
    if (orderId) {
      this.orderService.getOrderPositions(+orderId).subscribe({
        next: (pos) => {
          this.pos = pos;
        },
        error: (err) => console.error(err)
      });
    }
  }
}
