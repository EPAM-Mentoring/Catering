import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class BookingsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getBookingsForUser() {
    return this.http.get(this.baseUrl + 'bookings');
  }

  getBookingsDetailed(id: number) {
    return this.http.get(this.baseUrl + 'bookings/' + id);
  }
}
