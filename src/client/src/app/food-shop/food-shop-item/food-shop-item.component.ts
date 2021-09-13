import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IFood } from 'src/app/shared/models/food';
import { IFoodShop } from 'src/app/shared/models/foodShop';

@Component({
  selector: 'app-food-shop-item',
  templateUrl: './food-shop-item.component.html',
  styleUrls: ['./food-shop-item.component.scss']
})
export class FoodShopItemComponent implements OnInit {
  @Input() foodShop!: IFoodShop;
  @Input() food!: IFood;
  
  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  
  navigate() {
    this.router.navigate(['foods']);
  }
}
