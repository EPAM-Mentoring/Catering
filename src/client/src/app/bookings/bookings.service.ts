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
    return this.http.get(this.baseUrl + 'booking');
  }
  
  getBookingsDetailed(id: string) {
    return this.http.get(this.baseUrl + 'booking/' + id);
  }
}
