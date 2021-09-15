import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRestaurant } from '../shared/models/restaurant';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  baseUrl = 'https://catering-dev-tsk.azurewebsites.net/api/restaurants/';
  
  constructor(private httpClient: HttpClient) { }
  
  getRestaurants():Observable<Array<IRestaurant>> {
     return this.httpClient.get<Array<IRestaurant>>(this.baseUrl + "getAll");
  }

  getRestaurantById(id:number):Observable<IRestaurant> {
    return this.httpClient.get<IRestaurant>(this.baseUrl + id);
  }

  addRestaurant(restaurant:IRestaurant):Observable<IRestaurant>{
    return this.httpClient.post<IRestaurant>(this.baseUrl + "create", restaurant);
  }
  
  deleteRestaurantById(id:number):Observable<IRestaurant> {
    return this.httpClient.delete<IRestaurant>(this.baseUrl + id);
  }
}
