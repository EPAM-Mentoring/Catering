import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule} from 'ngx-bootstrap/carousel';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import { BookingSummaryComponent } from './components/booking-summary/booking-summary.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    TextInputComponent,
    OrderTotalsComponent,
    BookingSummaryComponent
  ],
  imports: [
    CommonModule,
    CarouselModule.forRoot(), 
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
   ReactiveFormsModule,
    CarouselModule,
    TextInputComponent,
    OrderTotalsComponent,
    BookingSummaryComponent
  ]
})

export class SharedModule { }
