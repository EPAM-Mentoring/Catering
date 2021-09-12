import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantComponent } from './restaurant.component';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component: RestaurantComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class RestaurantRoutingModule { }
