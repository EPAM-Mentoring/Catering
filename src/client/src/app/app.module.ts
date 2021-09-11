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
import { RestaurantModule } from './restaurant/restaurant.module';
import { FoodModule } from './food/food.module';
import { MealComponent } from './meal/meal.component';
import { MealModule } from './meal/meal.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    FoodShopModule,
    HomeModule,
    RestaurantModule,
    FoodModule,
    MealModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
