import { Component, OnInit } from '@angular/core';
import { IBooking } from '../shared/models/booking';
import { BookingsService } from './bookings.service';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.scss']
})
export class BookingsComponent implements OnInit {
  bookings: IBooking[];

  constructor(private bookingService: BookingsService) { }
  
  ngOnInit(): void {
    this.getBookings();
  }
  
  getBookings() {
    this.bookingService.getBookingsForUser().subscribe(
      (bookings: IBooking[]) => {
        this.bookings = bookings;
      },
      (error) => {
        console.log(error);
      }
    );
  }

}
