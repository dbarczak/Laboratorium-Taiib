import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderResponseDTO } from './models/order.interface';
import { HttpClient } from '@angular/common/http';
import { OrderPositionResponseDTO } from './models/order-position.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private httpClient: HttpClient) { }

  public getUserOrders(id: number): Observable<OrderResponseDTO[]> {
    return this.httpClient.get<OrderResponseDTO[]>(`https://localhost:7123/api/orders/${id}`);
  }

  public getAllOrders(): Observable<OrderResponseDTO[]> {
    return this.httpClient.get<OrderResponseDTO[]>(`https://localhost:7123/api/orders`);
  }

  public getOrderPositions(orderId: number): Observable<OrderPositionResponseDTO[]> {
    return this.httpClient.get<OrderPositionResponseDTO[]>(`https://localhost:7123/api/orders/${orderId}/positions`);
  }
}
