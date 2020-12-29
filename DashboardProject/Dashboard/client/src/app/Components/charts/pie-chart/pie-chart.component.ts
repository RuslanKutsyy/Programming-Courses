import { Component, Input, OnInit } from '@angular/core';
import _ from 'lodash';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {

  @Input() customersData: {}[];
  @Input() limit: number;

  constructor() { }

  pieChartData: number[] = [];
  pieChartLabels: string[] = [];
  pieChartColors: any[] = [
    {
      backgroundColor: ['#26547C', '#ff6b6b', "#ffd166", '#add424', '#ff6b6b', "#ffd166"],
      borderColor: '#111'
    }
  ];
  pieChartType = 'doughnut';

  ngOnInit(): void {
    this.customersData.slice(0, this.limit).map(result => {
      this.pieChartLabels.push(_.values(result)[0]);
      this.pieChartData.push(_.values(result)[1]);
    });
  }
}