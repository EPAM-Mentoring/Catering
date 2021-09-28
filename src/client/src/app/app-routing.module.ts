import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardAdmin } from './core/guards/auth-guard-admin';
import { AuthGuard } from './core/guards/auth.guard';
import { FoodShopComponent } from './food-shop/food-shop.component';
import { FoodComponent } from './food/food.component';
import { HomeComponent } from './home/home.component';
import { MealComponent } from './meal/meal.component';
import { RestaurantComponent } from './restaurant/restaurant.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'foodShops', loadChildren: () => import('./food-shop/food-shop.module').then(mod => mod.FoodShopModule)},
  {path: 'foods', component: FoodComponent},
  {path: 'restaurants', loadChildren: () => import('./restaurant/restaurant.module').then(mod => mod.RestaurantModule) },
  {path: 'meals', component: MealComponent},
  {path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule), data: {breadcrumb: {skip: true }} },
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  {
    path: 'checkout', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule)
  },
  {
    path: 'orders', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module').then(mod => mod.OrdersModule)
  },
  {path: '**', redirectTo: '', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    AuthGuard,
    AuthGuardAdmin
  ]
})
export class AppRoutingModule { }
