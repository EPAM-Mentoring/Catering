import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IMeal } from 'src/app/shared/models/meal';
import { IRestaurant } from 'src/app/shared/models/restaurant';

@Component({
  selector: 'app-restaurant-item',
  templateUrl: './restaurant-item.component.html',
  styleUrls: ['./restaurant-item.component.scss']
})
export class RestaurantItemComponent implements OnInit {
  @Input() restaurant!: IRestaurant;
  @Input() meal!: IMeal;
  
  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  
  navigate(){
    this.router.navigate(['foods']);
  }

}
