import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { IUser } from 'src/app/shared/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  basket$: Observable<IBasket>;
  public toggleFlag = false;

  currentUser$!: Observable<IUser>;

  constructor(private accountService: AccountService, private basketService: BasketService) { }
  
  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.basket$ = this.basketService.basket$;
  }

  logout() {
    this.accountService.logout();
  }

  showDropDown(){
    this.toggleFlag = !this.toggleFlag;
  }
}
