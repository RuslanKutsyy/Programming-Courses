import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../../../shared/order';

@Injectable({
  providedIn: 'root'
})
export class SalesDataServiceService {

  constructor(private http: HttpClient) { }

  public getOrders(pageIndex: number, pageSize: number) : Observable<any> {
    return this.http.get<any>(`http://localhost:5000/api/orders/${pageIndex}/${pageSize}`);
  }

  getOrdersByCustomer(id: number){
    return fetch(`http://localhost:5000/api/orders/ByCustomer/${id}`).then(res => res.json())
  }

  getOrdersByCity(){
    return fetch(`http://localhost:5000/api/order/ByCity`).then(res => res.json());
  }

}
