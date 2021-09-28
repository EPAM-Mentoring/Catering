import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IRestaurant } from 'src/app/shared/models/restaurant';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-detail',
  templateUrl: './restaurant-detail.component.html',
  styleUrls: ['./restaurant-detail.component.scss']
})
export class RestaurantDetailComponent implements OnInit {
  restaurants: any = [];
  rest: IRestaurant;

  constructor(private restaurantService: RestaurantService, private router: Router,
     private activatedRoute: ActivatedRoute)  { }
  
  ngOnInit() {
    this.loadRestaurant();
  }

  loadRestaurant() {
    this.restaurantService.getRestaurantById(+this.activatedRoute.snapshot.paramMap.get('id'))
    .subscribe(restaurant => {
          console.log(restaurant);
      this.restaurants.push(restaurant);
    }, error => console.log(error));
  }
}
