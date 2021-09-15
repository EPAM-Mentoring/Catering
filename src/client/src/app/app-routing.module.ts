import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FoodShopComponent } from './food-shop/food-shop.component';
import { FoodComponent } from './food/food.component';
import { HomeComponent } from './home/home.component';
import { MealComponent } from './meal/meal.component';
import { RestaurantComponent } from './restaurant/restaurant.component';

const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'} },
  {path: 'foodShops', component: FoodShopComponent},
  {path: 'foods', component: FoodComponent},
  {path: 'restaurants', component: RestaurantComponent},
  {path: 'meals', component: MealComponent},
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule), data: {breadcrumb: {skip: true }} },
  {path: '**', redirectTo: '', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
