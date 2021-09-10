import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { FoodShopModule } from './food-shop/food-shop.module';
import { FoodComponent } from './food/food.component';
import { HomeModule } from './home/home.module';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantItemComponent } from './restaurant/restaurant-item/restaurant-item.component';
import { RestaurantModule } from './restaurant/restaurant.module';

@NgModule({
  declarations: [
    AppComponent,
    FoodComponent,
    RestaurantComponent,
    RestaurantItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    FoodShopModule,
    HomeModule,
    RestaurantModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
