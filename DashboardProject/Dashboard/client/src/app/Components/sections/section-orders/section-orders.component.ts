import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Order } from '../../../shared/order';
import { SalesDataServiceService } from '../../services/sales-date-service/sales-data-service.service';

// const orders = [
//   {id: 1, 
//     customer: {id: 1, name: 'Ruslan Kutsyy', city: 'CO', email: 'rus@example.com'},
//     total:150, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)
//   },
//   {id: 2,
//     customer: {id: 1, name: 'Ruslan Kutsyy', city: 'CO', email: 'ru@example.com'},
//     total:290, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)},
//   {id: 3,
//     customer: {id: 1, name: 'Ruslan Kutsyy', state: 'CO', email: 'rus@example.com'},
//     total:50, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)},
//   {id: 4,
//     customer: {id: 1, name: 'Kseniya Margarit', state: 'CO', email: 'kseniya@example.com'},
//     total:120, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)},
//   {id: 5,
//     customer: {id: 1, name: 'Kseniya Margarit', state: 'CO', email: 'kseniya@example.com'},
//     total:400, placed: new Date(2017, 12, 1), fulfilled: new Date(2017, 12, 2)}
// ];

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css'],
  providers: [
    SalesDataServiceService
  ]
})
export class SectionOrdersComponent implements OnInit {

  constructor(private salesService: SalesDataServiceService) { }

  orders: Order[];
  totalPages: number;
  page = 1;
  limit = 10;
  totalOrders: number;
  loading = false;

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    // this.salesService.getOrders(this.page, this.limit).subscribe((response) => {
    //   this.totalPages = response['totalPages'];
    //   this.totalOrders = response['page']['total'];
    //   this.orders = response['page']['data'];
    //   this.loading = false;
    // });    


    this.salesService.getOrders(this.page, this.limit).pipe(map(response => {
      this.totalPages = response['totalPages'];
      this.totalOrders = response['page']['total'];
      this.orders = response['page']['data'];
      this.loading = false;
    })).subscribe(x => {});
  }

  goToPrevious() : void {
    // console.log("previous"); 
    this.page--;    
    this.getOrders();
  }

  goToNext() : void {
    // console.log("next");
    this.page++;    
    this.getOrders();
  }

  goToPage(n: number){
    this.page = n;
    this.getOrders();
  }

  getPages() : number[] {
    let arrPages = [];
    for (let i = 1; i <= this.totalPages; i++) {
      arrPages.push(i);
    }
    return arrPages;
  }
}
