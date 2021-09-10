import { Component, Input, OnInit } from '@angular/core';
import { IRestaurant } from 'src/app/shared/models/restaurant';

@Component({
  selector: 'app-restaurant-item',
  templateUrl: './restaurant-item.component.html',
  styleUrls: ['./restaurant-item.component.scss']
})
export class RestaurantItemComponent implements OnInit {
  @Input() restaurant!: IRestaurant;
  
  constructor() { }

  ngOnInit(): void {
  }

}
