import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CheckoutComponent } from './checkout.component';
import { CheckoutResultComponent } from './checkout-result/checkout-result.component';
import { CheckoutDeliveryComponent } from './checkout-delivery/checkout-delivery.component';
import { CheckoutReviewComponent } from './checkout-review/checkout-review.component';

const routes: Routes = [
  {path: 'address', component: CheckoutComponent},
  {path: 'result/:success', component: CheckoutResultComponent},
  {path: 'delivery', component: CheckoutDeliveryComponent},
  {path: 'review', component: CheckoutReviewComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class CheckoutRoutingModule { } 