import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasketService } from '../basket/basket.service';
import { IMeal } from '../shared/models/meal';
import { MealService } from './meal.service';

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
  styleUrls: ['./meal.component.scss']
})
export class MealComponent implements OnInit {

  meal: IMeal[] = [];
  quantity = 1;
  meal1: IMeal;

  constructor(private mealService: MealService, private basketService: BasketService, private router: Router) { }

  ngOnInit() {
    this.getMeals();
  }

  addMealItemToBasket(id: number) {
    this.meal1 = this.meal.find(m => m.id == id);
    this.basketService.addMealItemToBasket(this.meal1, this.quantity);
  }

  getMeals() {
    this.mealService.getMeals().subscribe(meals => {
      this.meal = meals;
      console.log(this.meal);
    })
  }
  
  deleteMealById(id:number) {
    this.mealService.deleteMealById(id).subscribe(res => {
      this.getMeals();
    })
  }

   incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }
}
