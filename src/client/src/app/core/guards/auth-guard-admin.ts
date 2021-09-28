import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';

@Injectable()
export class AuthGuardAdmin implements CanActivate {

  constructor(public account: AccountService) {}
  
  canActivate(): boolean {
    console.log("requesting for admin " , this.account.isAdmin);
    return this.account.isAdmin;
  }

}