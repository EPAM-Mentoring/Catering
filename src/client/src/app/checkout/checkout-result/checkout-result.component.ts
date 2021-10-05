import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketTotals } from 'src/app/shared/models/basket';
import { IOrder } from 'src/app/shared/models/order';

@Component({
  selector: 'app-checkout-result',
  templateUrl: './checkout-result.component.html',
  styleUrls: ['./checkout-result.component.scss']
})

export class CheckoutResultComponent implements OnInit {
  order: IOrder;
  public success: boolean = false;
  basketTotals$: Observable<IBasketTotals>;

  constructor(private router: Router, private activeRoute: ActivatedRoute, private basketService: BasketService) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation && navigation.extras && navigation.extras.state;
    if (state) {
      this.order = state as IOrder;
    }
    this.success = this.activeRoute.snapshot.params['success'];
    console.log('sucess : ', this.success);
    
    if (this.success) {
      console.log("order: ", this.order);
      if (this.order != null && this.order != undefined) {
        this.order.status = 'paid';
      }
    }
  }

  ngOnInit(): void {
      this.basketTotals$ = this.basketService.basketTotal$;
  }
}