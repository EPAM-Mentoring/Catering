import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookingsService } from 'src/app/bookings/bookings.service';
import { IRestaurant } from 'src/app/shared/models/restaurant';
import { RestaurantService } from '../restaurant.service';

@Component({
  selector: 'app-restaurant-detail',
  templateUrl: './restaurant-detail.component.html',
  styleUrls: ['./restaurant-detail.component.scss']
})
export class RestaurantDetailComponent implements OnInit {
  restaurants: IRestaurant[] = [];
  
  constructor(private restaurantService: RestaurantService, private router: Router,
     private activatedRoute: ActivatedRoute, private bookingService: BookingsService, 
     private toastr: ToastrService)  { }
     
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

  async bookRestaurant(id: number) {
    this.restaurantService.getRestaurantById(id).subscribe((restaurant) => {
      try {
        const booked = this.createBooking(restaurant);
        const navigationExtras: NavigationExtras = { state: booked };
        this.router.navigate(['booking', 'success'],  navigationExtras);
      } catch (error) {
        console.log(error);
      }
    });
  }
  
    private async createBooking(restaurant: IRestaurant) {
    const bookingToCreate = this.getBookingToCreate(restaurant);
    return this.restaurantService.createBooking(bookingToCreate).toPromise();
  }

  private getBookingToCreate(restaurant: IRestaurant) {
    return {
      restaurantId: restaurant.id
    };
  }
}
