import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodShopComponent } from './food-shop.component';
import { FoodShopItemComponent } from './food-shop-item/food-shop-item.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    FoodShopComponent,
    FoodShopItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [FoodShopComponent]
})
export class FoodShopModule { }
