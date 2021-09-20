import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasketService } from '../basket/basket.service';
import { IFood } from '../shared/models/food';
import { FoodService } from './food.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.scss']
})
export class FoodComponent implements OnInit {
  food: IFood[] = [];
  quantity = 1;
  food1: IFood;
  
  constructor(private foodService: FoodService, private basketService: BasketService, private router: Router) { }

  ngOnInit() {
    this.getFoods();
  }
  
  addItemToBasket(id: number) {
    this.food1 = this.food.find(f => f.id == id);
    this.basketService.addItemToBasket(this.food1, this.quantity);
  }
  
  getFoods() {
    this.foodService.getFoods().subscribe(foods => {
      this.food = foods;
    })
  }
  
  deleteFoodById(id:number) {
    this.foodService.deleteFoodById(id).subscribe(res => {
      this.getFoods();
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
