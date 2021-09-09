import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FoodShopComponent } from './food-shop/food-shop.component';
import { FoodComponent } from './food/food.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'foodShops', component: FoodShopComponent},
  {path: 'foods', component: FoodComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
