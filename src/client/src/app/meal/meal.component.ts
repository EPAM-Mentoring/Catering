import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IMeal } from '../shared/models/meal';
import { MealService } from './meal.service';

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
  styleUrls: ['./meal.component.scss']
})
export class MealComponent implements OnInit {
  
  meal!: Array<IMeal>;
  quantity = 1;

  constructor(private mealService: MealService, private router: Router) { }

  ngOnInit() {
    this.getMeals();
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
