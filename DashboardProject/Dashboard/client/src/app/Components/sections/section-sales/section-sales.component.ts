import { Component, OnInit } from '@angular/core';
import { SalesDataServiceService } from '../../services/sales-date-service/sales-data-service.service';

@Component({
  selector: 'app-section-sales',
  templateUrl: './section-sales.component.html',
  styleUrls: ['./section-sales.component.css']
})
export class SectionSalesComponent implements OnInit {

  byCustomersData: any;
  byCitiesData: any;

  constructor(private salesSrvc: SalesDataServiceService) { }

  ngOnInit(): void {
    this.salesSrvc.getOrdersByCustomer(5).subscribe(response => this.byCustomersData = response);
    this.salesSrvc.getOrdersByCity().subscribe(response => this.byCitiesData = response);
  }

}
