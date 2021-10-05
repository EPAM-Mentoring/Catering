import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket, IBasketTotals } from 'src/app/shared/models/basket';
import { IOrder } from 'src/app/shared/models/order';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})

export class CheckoutReviewComponent implements OnInit {
   @Input() checkoutForm: FormGroup;
   basket$: Observable<IBasket>;
   basketTotals$: Observable<IBasketTotals>;

   public url = new URL(
    'https://smartcity-citizenaccount-frontend.azurewebsites.net/payment/request'
  );

  constructor(private basketService: BasketService, private toastr: ToastrService, 
    private checkoutService: CheckoutService, private router: Router) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.basketTotals$ = this.basketService.basketTotal$;
  }
  
  openPaymentService() {
    const basket = this.basketService.getCurrentBasketValue();
    this.basketService.basketTotal$.subscribe((value) => {
      const createdOrder =  this.createOrder(basket);
      this.basket$.subscribe((order) => {
      let orderId = order.id;
      let amount = value.total;
      let serviceId = 3;
      
      this.url.searchParams.append('orderId', orderId.toString());
      this.url.searchParams.append('amount', amount.toString());
      this.url.searchParams.append('serviceId', serviceId.toString());
      this.url.searchParams.append('category', "catering");
      window.open(this.url.toString(), '_blank').focus();
    });
  });
  }
  
  private async createOrder(basket: IBasket) {
    const orderToCreate = this.getOrderToCreate(basket);
    return this.checkoutService.createOrder(orderToCreate).toPromise();
  }
  
  private getOrderToCreate(basket: IBasket) {
    return {
      basketId: basket.id,
      deliveryMethodId: this.checkoutForm.get('deliveryForm').get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('addressForm').value
    };
  }

}
