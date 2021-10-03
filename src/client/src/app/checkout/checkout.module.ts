import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { SharedModule } from '../shared/shared.module';
import { CheckoutRoutingModule } from './checkout-routing.module';
import { CheckoutResultComponent } from './checkout-result/checkout-result.component';
import { CheckoutDeliveryComponent } from './checkout-delivery/checkout-delivery.component';
import { CheckoutReviewComponent } from './checkout-review/checkout-review.component';
import { BasketSummaryModule } from '../shared/components/basket-summary/basket-summary.module';


@NgModule({
  declarations: [CheckoutComponent, CheckoutResultComponent, CheckoutDeliveryComponent, CheckoutReviewComponent],
  imports: [
    CommonModule,
    CheckoutRoutingModule,
    SharedModule,
    BasketSummaryModule,
  ]
})
export class CheckoutModule {}