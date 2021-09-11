import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IFood } from '../shared/models/food';
import { FoodService } from './food.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.scss']
})
export class FoodComponent implements OnInit {
  food!: Array<IFood>;
  quantity = 1;

  constructor(private foodService: FoodService, private router: Router) { }

  ngOnInit() {
    this.getFoods();
  }

  getFoods() {
    this.foodService.getFoods().subscribe(foods => {
      this.food = foods;
      console.log(this.food);
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
