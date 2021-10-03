import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket, IBasketTotals } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent implements OnInit {
   basket$: Observable<IBasket>;
   basketTotals$: Observable<IBasketTotals>;
  
   public url = new URL(
    'https://smartcity-citizenaccount-frontend.azurewebsites.net/payment/request'
  );

  constructor(private basketService: BasketService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.basketTotals$ = this.basketService.basketTotal$;
  }

  openPaymentService() {
    this.basketService.basketTotal$.subscribe((value) => {
      let orderId = 1;
      let amount = value.total;
      let serviceId = 3;
      
      this.url.searchParams.append('orderId', orderId.toString());
      this.url.searchParams.append('amount', amount.toString());
      this.url.searchParams.append('serviceId', serviceId.toString());

      window.open(this.url.toString(), '_blank').focus();
    });
  }

}
