import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule} from 'ngx-bootstrap/carousel';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    TextInputComponent
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
    TextInputComponent
  ]
})
export class SharedModule { }
