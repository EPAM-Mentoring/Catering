import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IBooking } from 'src/app/shared/models/booking';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BookingsService } from '../bookings.service';

@Component({
  selector: 'app-booking-result',
  templateUrl: './booking-result.component.html',
  styleUrls: ['./booking-result.component.scss']
})
export class BookingResultComponent implements OnInit {
  booking: IBooking;
  
  constructor(private router: Router, private route: ActivatedRoute, private breadcrumbService: BreadcrumbService, 
    private bookingService: BookingsService) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation && navigation.extras && navigation.extras.state;
    if (state) {
      this.booking = state as IBooking;
    }
   }
    
   ngOnInit(): void {
    
  }


}
