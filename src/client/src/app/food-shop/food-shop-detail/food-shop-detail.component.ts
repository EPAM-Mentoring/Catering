import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FoodShopService } from '../food-shop.service';

@Component({
  selector: 'app-food-shop-detail',
  templateUrl: './food-shop-detail.component.html',
  styleUrls: ['./food-shop-detail.component.scss']
})
export class FoodShopDetailComponent implements OnInit {

  foodShops: any = [];

  constructor(private foodShopService: FoodShopService, private router: Router,
     private activatedRoute: ActivatedRoute)  { }
  
  ngOnInit() {
    this.loadFoodShop();
  }

  loadFoodShop() {
    this.foodShopService.getFoodShopById(+this.activatedRoute.snapshot.paramMap.get('id'))
    .subscribe(foodShop => {
      this.foodShops.push(foodShop);
    }, error => console.log(error));
  }
}
