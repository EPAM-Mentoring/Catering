import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBookingToCreate } from '../shared/models/booking';
import { IRestaurant } from '../shared/models/restaurant';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  baseUrl = environment.apiUrl + 'restaurants/';
  bookUrl = environment.apiUrl + 'booking';
  private restaurantSource = new BehaviorSubject<IRestaurant>(null);
  
  restaurants: IRestaurant[] = [];

  constructor(private httpClient: HttpClient) { }
  
  getCurrentRestaurantValue(): IRestaurant {
    return this.restaurantSource.getValue();
  }

  getRestaurants(): Observable<Array<IRestaurant>> {
     return this.httpClient.get<Array<IRestaurant>>(this.baseUrl + "getAll");
  }

  getRestaurantById(id:number):Observable<IRestaurant> {
    return this.httpClient.get<IRestaurant>(this.baseUrl + id);
  }

  addRestaurant(restaurant:IRestaurant):Observable<IRestaurant>{
    return this.httpClient.post<IRestaurant>(this.baseUrl + "create", restaurant);
  }
  
  updateRestaurantById(id:number):Observable<IRestaurant>{
    return this.httpClient.put<IRestaurant>(this.baseUrl + '', id);
  }

  deleteRestaurantById(id:number):Observable<IRestaurant> {
    return this.httpClient.delete<IRestaurant>(this.baseUrl + id);
  }
  
  createBooking(booking: IBookingToCreate) {
     return this.httpClient.post(this.bookUrl, booking);
  }

  updateRestaurantStatus(id: number) {
    return this.httpClient.post(this.baseUrl + '', id);
  }
}
