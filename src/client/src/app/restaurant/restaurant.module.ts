import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantComponent } from './restaurant.component';
import { SharedModule } from '../shared/shared.module';
import { RestaurantItemComponent } from './restaurant-item/restaurant-item.component';
import { RestaurantDetailComponent } from './restaurant-detail/restaurant-detail.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RestaurantRoutingModule } from './restaurant-routing.module';

@NgModule({
  declarations: [
    RestaurantComponent,
    RestaurantItemComponent,
    RestaurantDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    FormsModule,
    RestaurantRoutingModule
  ]
})
export class RestaurantModule { }
