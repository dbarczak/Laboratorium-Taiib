import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductResponseDTO } from './models/product.interface';
import { PaginationDTO } from './models/pagination.interface';
import { ProductRequestDTO } from './models/product_request.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient: HttpClient) { }

  public getProducts(pagination: PaginationDTO, nameF: string, isActive: boolean, sortB: string, sorting: boolean): Observable<ProductResponseDTO[]>{
    return this.httpClient.get<ProductResponseDTO[]>(
      'https://localhost:7123/api/products',{params:{
        page: pagination.page ?? 0,
        count: pagination.count ?? 10,
        nameFilter: nameF ?? null,
        isActiveFilter: isActive ?? null,
        sortBy: sortB ?? null,
        sortAscending: sorting ?? null
      },

    }
    );
  }

  public getProductById(id: number): Observable<ProductResponseDTO>{
    return this.httpClient.get<ProductResponseDTO>(`https://localhost:7123/api/products/${id}`)
  }

  public deleteProduct(id: number): Observable<void>{
    return this.httpClient.delete<void>(`https://localhost:7123/api/products/${id}`);
  }

  public activateProduct(id: number): Observable<void>{
    return this.httpClient.put<void>(`https://localhost:7123/api/products/Activate/${id}`, null);
  }

  public updateProduct(id: number, product: ProductRequestDTO): Observable<void>{
    return this.httpClient.put<void>(`https://localhost:7123/api/products/${id}`, product);
  }

  public addProduct(product: ProductRequestDTO): Observable<void>{
    return this.httpClient.post<void>('https://localhost:7123/api/products', product);
  }

}
