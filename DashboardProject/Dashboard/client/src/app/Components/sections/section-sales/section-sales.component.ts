import { Component, OnInit } from '@angular/core';
import { CustomerDataService } from '../../services/customer-data-service/customer-data.service';
import { SalesDataServiceService } from '../../services/sales-date-service/sales-data-service.service';

@Component({
  selector: 'app-section-sales',
  templateUrl: './section-sales.component.html',
  styleUrls: ['./section-sales.component.css']
})
export class SectionSalesComponent implements OnInit {

  byCustomersData: any;
  byCitiesData: any;
  lineChartCustomerData: any;

  constructor(private salesSrvc: SalesDataServiceService, private custSvc : CustomerDataService) { }

  ngOnInit(): void {
    this.salesSrvc.getOrdersByCustomer(5).subscribe(response => this.byCustomersData = response);
    this.salesSrvc.getOrdersByCity().subscribe(response => this.byCitiesData = response);
    this.custSvc.getTopCustomersAndOrders(5).subscribe(response => this.lineChartCustomerData = response);
  }

}
