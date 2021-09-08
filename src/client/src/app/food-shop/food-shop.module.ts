import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodShopComponent } from './food-shop.component';
import { FoodShopItemComponent } from './food-shop-item/food-shop-item.component';
import { SharedModule } from '../shared/shared.module';
import { FoodComponent } from './food/food.component';



@NgModule({
  declarations: [
    FoodShopComponent,
    FoodShopItemComponent,
    FoodComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [FoodShopComponent]
})
export class FoodShopModule { }
