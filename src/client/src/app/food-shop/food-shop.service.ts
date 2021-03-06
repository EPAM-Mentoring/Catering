import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IFoodShop } from '../shared/models/foodShop';

@Injectable({
  providedIn: 'root'
})

export class FoodShopService {
  baseUrl = environment.apiUrl + 'foodShops/';
  
  constructor(private httpClient: HttpClient) { }
  
  getFoodShops():Observable<Array<IFoodShop>> {
     return this.httpClient.get<Array<IFoodShop>>(this.baseUrl + 'getAll');
  }
  
  getFoodShopById(id:number):Observable<IFoodShop> {
    return this.httpClient.get<IFoodShop>(this.baseUrl + id);
  }
  
  addFoodShop(foodShop:IFoodShop):Observable<IFoodShop>{
    return this.httpClient.post<IFoodShop>(this.baseUrl + 'create', foodShop);
  }

  updateFoodShopById(id:number):Observable<IFoodShop> {
    return this.httpClient.put<IFoodShop>(this.baseUrl + '', id);
  }

  deleteFoodShopById(id:number):Observable<IFoodShop> {
    return this.httpClient.delete<IFoodShop>(this.baseUrl + id);
  } 

}

