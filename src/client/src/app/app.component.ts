import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Catering';
  constructor(private accountService: AccountService, private basketService: BasketService) { }
  
  ngOnInit(): void {
    this.loadCurrentUser();
    this.loadBasket();
  }
  
  loadCurrentUser() {
    const token: any = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(() => {
      console.log('loaded user');
    }, error => {
      console.log(error);
    })
  }
  
  loadBasket() {
    const basketId:number = Number(localStorage.getItem('basket_id'));
    if(basketId) {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('initialized basket');
      }, error => {
        console.log(error)
      });
    }
  }
  
}