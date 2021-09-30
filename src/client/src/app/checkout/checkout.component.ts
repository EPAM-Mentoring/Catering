import { Component, OnInit } from '@angular/core';
import { BasketService } from '../basket/basket.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  public url = new URL(
    'https://smartcity-citizenaccount-frontend.azurewebsites.net/payment/request'
  );

  constructor(private basket: BasketService) { }

  ngOnInit(): void {
  }
  
  openPaymentService() {
    this.basket.basketTotal$.subscribe((value) => {
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
