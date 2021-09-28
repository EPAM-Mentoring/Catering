import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodShopComponent } from './food-shop.component';
import { FoodShopItemComponent } from './food-shop-item/food-shop-item.component';
import { SharedModule } from '../shared/shared.module';
import { FoodShopDetailComponent } from './food-shop-detail/food-shop-detail.component';
import { FormsModule } from '@angular/forms';
import { FoodShopRoutingModule } from './food-shop-routing.module';


@NgModule({
  declarations: [
    FoodShopComponent,
    FoodShopItemComponent,
    FoodShopDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    FoodShopRoutingModule
  ],
  exports: [FoodShopComponent]
})
export class FoodShopModule { }
