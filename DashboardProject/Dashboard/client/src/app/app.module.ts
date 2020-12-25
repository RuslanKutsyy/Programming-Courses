import { BrowserModule } from '@angular/platform-browser';
import { RouterModule} from '@angular/router';

import { appRoutes} from '../routes';

import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { SidebarComponent } from './Components/sidebar/sidebar.component';
import { SectionSalesComponent } from './Components/sections/section-sales/section-sales.component';
import { SectionOrdersComponent } from './Components/sections/section-orders/section-orders.component';
import { SectionHealthComponent } from './Components/sections/section-health/section-health.component';
import { BarChartComponent } from './Components/charts/bar-chart/bar-chart.component';
import { LineChartComponent } from './Components/charts/line-chart/line-chart.component';
import { PieChartComponent } from './Components/charts/pie-chart/pie-chart.component';
import { ServerComponent } from './server/server.component';
import { PaginationComponent } from './Components/pagination/pagination.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    SectionSalesComponent,
    SectionOrdersComponent,
    SectionHealthComponent,
    BarChartComponent,
    LineChartComponent,
    PieChartComponent,
    ServerComponent,
    PaginationComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    ChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
