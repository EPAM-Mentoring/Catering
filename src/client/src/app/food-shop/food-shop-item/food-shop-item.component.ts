import { Component, Input, OnInit } from '@angular/core';
import { IFoodShop } from 'src/app/shared/models/foodShop';

@Component({
  selector: 'app-food-shop-item',
  templateUrl: './food-shop-item.component.html',
  styleUrls: ['./food-shop-item.component.scss']
})
export class FoodShopItemComponent implements OnInit {
  @Input() foodShop!: IFoodShop;
  
  constructor() { }

  ngOnInit(): void {
  }

}
