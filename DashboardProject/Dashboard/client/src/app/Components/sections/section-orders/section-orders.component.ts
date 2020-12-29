import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Order } from '../../../shared/order';
import { SalesDataServiceService } from '../../services/sales-date-service/sales-data-service.service';
import * as moment from 'moment';


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

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.salesService.getOrders(this.page, this.limit).pipe(map(response => {
      this.totalPages = response['totalPages'];
      this.totalOrders = response['page']['total'];
      this.orders = response['page']['data'];
    })).subscribe(x => {});
  }

  goToPrevious() : void {
    this.page--;    
    this.getOrders();
  }

  goToNext() : void {
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
