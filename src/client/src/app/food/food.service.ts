import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { IFood } from '../shared/models/food';

@Injectable({
  providedIn: 'root'
})

export class FoodService {
  baseUrl = environment.apiUrl + 'foods/';

  constructor(private httpClient: HttpClient) { }
  
  getFoods():Observable<Array<IFood>> {
     return this.httpClient.get<Array<IFood>>(this.baseUrl + "getAll");
  }
  
   getFoodById(id:number):Observable<IFood> {
    return this.httpClient.get<IFood>(this.baseUrl + id);
  }

  addFood(foodShop:IFood):Observable<IFood>{
    return this.httpClient.post<IFood>(this.baseUrl + "create", foodShop);
  }

  deleteFoodById(id:number):Observable<IFood> {
    return this.httpClient.delete<IFood>(this.baseUrl + id);
  } 
}
