import { Component, OnInit } from '@angular/core';
import { SalesDataServiceService } from '../../services/sales-date-service/sales-data-service.service';
import * as moment from 'moment';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {

  constructor(private salesSvc : SalesDataServiceService) { }

  orders: any;
  ordersLabels: string[];
  ordersData: number[];

  public barChartData: any[];;
  public barChartLabels: string[];
  public barChartType = 'bar';
  public barChartLegend = true;
  public barChartOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true
  }

  ngOnInit(): void {
    this.salesSvc.getOrders(1, 20).subscribe(response => {
      const localChartData = this.getChartData(response);
      this.barChartLabels = localChartData.map(x => x[0]).reverse();
      this.barChartData = [{"data": localChartData.map(x => x[1]).reverse(), "label": "Sales"}]
    });
  }

  getChartData(res: Response){
    this.orders = res['page']['data'];
    const filteredData = this.orders.map(o => [moment(new Date(o.placed)).format("MMM"), o.totalPrice]);
    
    const p = [];

    const chartData = filteredData.reduce((r, e) => {
      const key = e[0];
      if(!p[key]){
        p[key] = e;
        r.push(p[key]);
      } else {
        p[key][1] += e[1];
      }
      return r
    }, []);

    return chartData;
  }
}
