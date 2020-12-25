import { Component, OnInit } from '@angular/core';
import { Order } from '../../../shared/order';

const orders = [
  {id: 1, 
    customer: {id: 1, name: 'Ruslan Kutsyy', state: 'CO', email: 'rus@example.com'},
    total:150, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)
  },
  {id: 2,
    customer: {id: 1, name: 'Ruslan Kutsyy', state: 'CO', email: 'ru@example.com'},
    total:290, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)},
  {id: 3,
    customer: {id: 1, name: 'Ruslan Kutsyy', state: 'CO', email: 'rus@example.com'},
    total:50, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)},
  {id: 4,
    customer: {id: 1, name: 'Kseniya Margarit', state: 'CO', email: 'kseniya@example.com'},
    total:120, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)},
  {id: 5,
    customer: {id: 1, name: 'Kseniya Margarit', state: 'CO', email: 'kseniya@example.com'},
    total:400, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)}
];

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {

  constructor() { }

  orders: Order[];

  ngOnInit(): void {
    this.orders = orders;
  }

  goToPrevious() : void {
    console.log("previous"); 
  }

  goToNext() : void {
    console.log("next");    
  }
}
