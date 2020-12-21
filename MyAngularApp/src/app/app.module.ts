import { BrowserModule } from '@angular/platform-browser';
import { RouterModule} from '@angular/router';

import { appRoutes} from '../routes';

import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { SidebarComponent } from '../app/Components/Administration/sidebar/sidebar.component';
import { SectionSalesComponent } from './Components/Administration/sections/section-sales/section-sales.component';
import { SectionOrdersComponent } from './Components/Administration/sections/section-orders/section-orders.component';
import { SectionHealthComponent } from './Components/Administration/sections/section-health/section-health.component';
import { BarChartComponent } from './Components/Administration/charts/bar-chart/bar-chart.component';
import { LineChartComponent } from './Components/Administration/charts/line-chart/line-chart.component';
import { PieChartComponent } from './Components/Administration/charts/pie-chart/pie-chart.component';
import { ServerComponent } from './server/server.component';
import { AdministrationComponent } from '../app/Components/Administration/administration/administration.component';
import { PresentationComponent } from './Components/presentation/presentation.component';
import { HomeComponent } from './Components/Home/home/home.component';
import { AboutComponent } from './Components/about/about.component';
import { FooterComponent } from './Components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PresentationComponent,
    HomeComponent,
    SidebarComponent,
    SectionSalesComponent,
    SectionOrdersComponent,
    SectionHealthComponent,
    BarChartComponent,
    LineChartComponent,
    PieChartComponent,
    ServerComponent,
    AdministrationComponent,
    AboutComponent,
    FooterComponent
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
