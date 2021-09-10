import { Component, OnInit } from '@angular/core';
import { IRestaurant } from '../shared/models/restaurant';
import { RestaurantService } from './restaurant.service';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})

export class RestaurantComponent implements OnInit {
  restaurant!: Array<IRestaurant>;

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit() {
    this.getRestaurants();
  }
  
  getRestaurants() {
    this.restaurantService.getRestaurants().subscribe(restaurants => {
      this.restaurant = restaurants;
      console.log(this.restaurant);
    })
  }
  
  deleteRestaurantyId(id:number) {
    this.restaurantService.deleteRestaurantById(id).subscribe(res => {
      this.getRestaurants();
    })
  }
}
