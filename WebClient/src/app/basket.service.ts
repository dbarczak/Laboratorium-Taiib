import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BasketPositionResponseDTO } from './models/basket.interface';
import { BasketPositionRequestDTO } from './models/basket-request.interface';
@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private httpClient: HttpClient) { }

  public getUserBasket(userId: number): Observable<BasketPositionResponseDTO[]> {
    return this.httpClient.get<BasketPositionResponseDTO[]>(`https://localhost:7123/api/basketpositions/${userId}`);
  }

  public addToBasket(basketPos: BasketPositionRequestDTO): Observable<BasketPositionRequestDTO> {
    return this.httpClient.post<BasketPositionRequestDTO>(`https://localhost:7123/api/basketpositions/`, basketPos)
  }

  public changeAmount(id: number, amount: number): Observable<void> {
    return this.httpClient.put<void>(`https://localhost:7123/api/basketpositions/Amount/${id}`, amount);
  }

  public removeFromBasket(id: number): Observable<void> {
    return this.httpClient.delete<void>(`https://localhost:7123/api/basketpositions/${id}`)
  }

  public createOrder(id: number): Observable<void> {
    return this.httpClient.post<void>(`https://localhost:7123/api/basketpositions/order/${id}`,null)
  }
}
