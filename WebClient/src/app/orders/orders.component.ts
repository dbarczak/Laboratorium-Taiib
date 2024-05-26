import { Component } from '@angular/core';
import { OrderResponseDTO } from '../models/order.interface';
import { OrdersService } from '../orders.service';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent {
  public data: OrderResponseDTO[] = [];
  public id: number = 1;
  public isAllOrdersPage: boolean = false;
  public choosedOrder?: OrderResponseDTO = undefined;

  constructor(private ordersService: OrdersService, private route: ActivatedRoute, private router: Router) {
    this.checkPage();
    this.getData();
  }

  private getData(): void {
    if (!this.isAllOrdersPage) {
      this.ordersService.getUserOrders(this.id).subscribe({
        next: (res) => {
          this.data = res;
        },
        error: (err) => console.error(err),
        complete: () => console.log('complete')
      });
    }
    else{
      this.ordersService.getAllOrders().subscribe({
        next: (res) => {
          this.data = res;
        },
        error: (err) => console.error(err),
        complete: () => console.log('complete')
      });
    }
  }

  private checkPage(): void {
    this.route.url.subscribe(urlSegments => {
      const current = urlSegments.map(segment => segment.path).join('/');
      this.isAllOrdersPage = current === 'orders/all';
    });
  }

  public toPage(orderId: number){
    if(this.isAllOrdersPage) this.router.navigate(['/orders/all/', orderId]);
    else this.router.navigate(['/orders/', orderId]);
  }
}
