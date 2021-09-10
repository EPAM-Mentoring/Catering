import { Component, OnInit } from '@angular/core';
import { IFoodShop } from '../shared/models/foodShop';
import { FoodShopService } from './food-shop.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-food-shop',
  templateUrl: './food-shop.component.html',
  styleUrls: ['./food-shop.component.scss']
})

export class FoodShopComponent implements OnInit {
  foodShop!: Array<IFoodShop>;

  constructor(private foodShopService: FoodShopService, private router: Router) { }

  ngOnInit() {
    this.getFoodShops();
  }
  
  getFoodShops() {
    this.foodShopService.getFoodShops().subscribe(foodShops => {
      this.foodShop = foodShops;
      console.log(this.foodShop);
    })
  }
  
  deleteFoodShopById(id:number) {
    this.foodShopService.deleteFoodShopById(id).subscribe(res => {
      this.getFoodShops();
    })
  }
}
