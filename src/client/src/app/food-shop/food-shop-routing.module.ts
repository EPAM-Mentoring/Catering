import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FoodShopComponent } from './food-shop.component';
import { FoodComponent } from '../food/food.component';
import { FoodShopDetailComponent } from './food-shop-detail/food-shop-detail.component';

const routes: Routes = [
  { path: '', component: FoodShopComponent },
  { path: ':id', component: FoodShopDetailComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class FoodShopRoutingModule { }
