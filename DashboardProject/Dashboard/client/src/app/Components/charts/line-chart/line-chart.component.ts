import { Component, Input, OnInit } from '@angular/core';
import { LINE_CHART_COLORS } from '../../../shared/chart.colors';
import * as moment from 'moment';

// const LINE_CHART_SAMPLE_DATA: any[] = [
//   { data: [32, 14, 46, 23, 38, 56], label: 'Sentiment Analysis'},
//   { data: [12, 18, 26, 13, 28, 26], label: 'Image Recognition'},
//   { data: [52, 34, 49, 53, 68, 66], label: 'Forecasting'}
// ]

const LINE_CHART_LABELS: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor() { }

  @Input() customerData: any

  lineChartData: any = [];
  lineChartLabels: string[] = LINE_CHART_LABELS;
  lineChartOptions: any = {
    responsive: true,
    maintainAspectRatio: false
  };
  lineChartLegend: true;
  lineChartType = 'line';
  lineChartColors = LINE_CHART_COLORS;

  ngOnInit(): void {
    this.customerData.map(cust => {
      let input = {data: Array(12).fill(0), label: `${cust.firstName} ${cust.lastName}`};
      cust.orders.map(ord => {
        let month = Number(moment(new Date(ord.placed)).format("M"));
        input.data[month] = ord.totalPrice;
      });
      this.lineChartData.push(input);
    });
  }
}