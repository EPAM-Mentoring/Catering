import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IOrderToCreate } from '../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

   baseUrl = environment.apiUrl;

   constructor(private http: HttpClient) { }

   createOrder(order: IOrderToCreate) {
     return this.http.post(this.baseUrl + 'orders', order);
   }
}
