import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantComponent } from './restaurant.component';
import { SharedModule } from '../shared/shared.module';
import { RestaurantItemComponent } from './restaurant-item/restaurant-item.component';


@NgModule({
  declarations: [
    RestaurantComponent,
    RestaurantItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [RestaurantComponent] 
})
export class RestaurantModule { }
