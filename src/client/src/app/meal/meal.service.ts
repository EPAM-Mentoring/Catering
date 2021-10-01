import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IFood } from '../shared/models/food';
import { IMeal } from '../shared/models/meal';

@Injectable({
  providedIn: 'root'
})
export class MealService {
  baseUrl = environment.apiUrl + 'meals/';
  
  constructor(private httpClient: HttpClient) { }
  
  getMeals():Observable<Array<IMeal>> {
     return this.httpClient.get<Array<IMeal>>(this.baseUrl + "getAll");
  }
  
   getMealById(id:number):Observable<IMeal> {
    return this.httpClient.get<IMeal>(this.baseUrl + id);
  }

  addMeal(mealItem:IMeal):Observable<IMeal>{
    return this.httpClient.post<IMeal>(this.baseUrl + "create", mealItem);
  }

  deleteMealById(id:number):Observable<IMeal> {
    return this.httpClient.delete<IMeal>(this.baseUrl + id);
  } 
}
