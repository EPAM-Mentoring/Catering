import { NgModule } from '@angular/core';
import { BookingsComponent } from './bookings.component';
import { RouterModule, Routes } from '@angular/router';
import { BookingResultComponent } from './booking-result/booking-result.component';

const routes: Routes = [
  {path: '', component: BookingsComponent},
  {path: 'success', component: BookingResultComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class BookingRoutingModule { }
