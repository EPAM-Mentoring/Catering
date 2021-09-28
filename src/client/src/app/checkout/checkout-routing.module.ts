import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CheckoutComponent } from './checkout.component';
import { CheckoutResultComponent } from './checkout-result/checkout-result.component';

const routes: Routes = [
  {path: '', component: CheckoutComponent},
  {path: 'result/:success', component: CheckoutResultComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class CheckoutRoutingModule { } 