import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';

@Component({
  selector: 'app-checkout-result',
  templateUrl: './checkout-result.component.html',
  styleUrls: ['./checkout-result.component.scss']
})

export class CheckoutResultComponent implements OnInit {
  order: IOrder;
  public success: boolean = false;

  constructor(private router: Router, private activeRoute: ActivatedRoute) {
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

  ngOnInit(): void {}
}