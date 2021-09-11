import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodComponent } from './food.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [FoodComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
   exports: [FoodComponent]
})
export class FoodModule { }
