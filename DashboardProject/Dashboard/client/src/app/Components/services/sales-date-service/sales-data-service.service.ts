import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SalesDataServiceService {

  constructor() { }

  getOrders(pageIndex: number, pageSize: number){
    return fetch(`http://localhost:5000/api/order/${pageIndex}/${pageSize}`).then(res => res.json());
  }

  getOrdersByCustomer(id: number){
    return fetch(`http://localhost:5000/api/order/ByCustomer/${id}`).then(res => res.json())
  }

  getOrdersByCity(){
    return fetch(`http://localhost:5000/api/order/ByCity`).then(res => res.json());
  }

}
