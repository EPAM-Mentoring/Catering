import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketTotals } from 'src/app/shared/models/basket';
import { IDeliveryMethod } from 'src/app/shared/models/deliveryMethod';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {

  @Input() checkoutForm: FormGroup;
  deliveryMethods: IDeliveryMethod[];
  basketTotals$: Observable<IBasketTotals>;

  constructor(private fb: FormBuilder, private accountService: AccountService, 
    private basketService: BasketService, private toastr: ToastrService, private checkoutService: CheckoutService) {}

  ngOnInit() : void  {
    this.basketTotals$ = this.basketService.basketTotal$;
    this.getDeliveryMethodValue
    this.checkoutService.getDeliveryMethods()
        .subscribe((dm: IDeliveryMethod[]) => {
          this.deliveryMethods = dm;
        }, error => console.log(error));

    this.checkoutForm = new FormGroup({
       deliveryForm: new FormControl()
    });
  }
  
  getDeliveryMethodValue() {
    const basket = this.basketService.getCurrentBasketValue();
    if (basket.deliveryMethodId !== null) {
      this.checkoutForm.get('deliveryForm').get('deliveryMethod')
        .patchValue(basket.deliveryMethodId.toString());
    }
  }
  
  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.basketService.setShippingPrice(deliveryMethod);
  }
}