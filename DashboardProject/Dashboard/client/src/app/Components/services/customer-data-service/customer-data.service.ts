import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerDataService {

  constructor(private http: HttpClient) { }

  public getTopCustomersAndOrders(top: number) : Observable<any> {
    return this.http.get(`https://localhost:5001/api/customers/GetTopCustomersAndOrders/${top}`);
  }
}
