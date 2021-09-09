import { Component, OnInit } from '@angular/core';
import { IFoodShop } from '../shared/models/foodShop';
import { FoodShopService } from './food-shop.service';

@Component({
  selector: 'app-food-shop',
  templateUrl: './food-shop.component.html',
  styleUrls: ['./food-shop.component.scss']
})

export class FoodShopComponent implements OnInit {
  foodShops !: IFoodShop[];
  constructor(private foodShopService: FoodShopService) { }

  ngOnInit() {
    this.getFoodShops();
  }

  getFoodShops() {
     this.foodShopService.getFoodShops().subscribe((response: any) => {
      this.foodShops = response.data;
    }), (error: any)=> {
      console.log(error);
    }
  }
  
}
