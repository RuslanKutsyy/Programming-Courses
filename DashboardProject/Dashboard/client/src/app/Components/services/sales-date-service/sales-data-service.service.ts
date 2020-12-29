import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesDataServiceService {

  constructor(private http: HttpClient) { }

  public getOrders(pageIndex: number, pageSize: number) : Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/orders/${pageIndex}/${pageSize}`);
  }

  getOrdersByCustomer(id: number) : Observable<any> {
    return this.http.get(`http://localhost:5000/api/orders/ByCustomer/${id}`);
  }

  getOrdersByCity() : Observable<any>{
    return this.http.get(`http://localhost:5000/api/orders/ByCity`);
  }
}
