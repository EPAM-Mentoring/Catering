import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BasketSummaryComponent } from './basket-summary.component';


@NgModule({
  declarations: [BasketSummaryComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [BasketSummaryComponent]
})
export class BasketSummaryModule { }
