import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule} from 'ngx-bootstrap/carousel';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { RouterModule } from '@angular/router';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
@NgModule({
  declarations: [
    TextInputComponent,
    OrderTotalsComponent
  ],
  imports: [
    CommonModule,
    CarouselModule.forRoot(), 
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
   ReactiveFormsModule,
    CarouselModule,
    TextInputComponent,
    OrderTotalsComponent
  ]
})

export class SharedModule { }
