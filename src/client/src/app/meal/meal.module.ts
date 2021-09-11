import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MealComponent } from './meal.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [MealComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [MealComponent]
})
export class MealModule { }
