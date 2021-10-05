import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-booking-summary',
  templateUrl: './booking-summary.component.html',
  styleUrls: ['./booking-summary.component.scss']
})
export class BookingSummaryComponent implements OnInit {
   @Input() items: any;
   @Input() isBooking = true;
   @Input() isBooked = false;
  constructor() { }


  ngOnInit(): void {
  }

}
