import { Routes } from '@angular/router';
import { HomeComponent } from './app/Components/Home/home/home.component';
import { AdministrationComponent } from './app/Components/Administration/administration/administration.component'
import { AboutComponent } from './app/Components/about/about.component';
import { SectionSalesComponent } from './app/Components/Administration/sections/section-sales/section-sales.component';
import { SectionOrdersComponent } from './app/Components/Administration/sections/section-orders/section-orders.component';
import { SectionHealthComponent } from './app/Components/Administration/sections/section-health/section-health.component';
// import { SectionSalesComponent } from "./app/Components/sections/section-sales/section-sales.component";
// import { SectionOrdersComponent } from "./app/Sections/section-orders/section-orders.component";
// import { SectionHealthComponent } from "./app/Sections/section-health/section-health.component";

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'about', component: AboutComponent},
    // { path: 'blog',},
    // { path: 'portfolio', },
    // { path: 'offers', },
    // { path: 'shop',  },
    // { path: 'review', },
    // { path: 'info', },
    // { path: 'contacts', },
    { path: 'administration', component: AdministrationComponent,
        children: [
            { path: 'sales', component: SectionSalesComponent },
            { path: 'orders', component: SectionOrdersComponent },
            { path: 'health', component: SectionHealthComponent }
        ]
    },

    { path: '', redirectTo: '/home', pathMatch: 'full' }
];


// export const appRoutes: Routes = [
//     { path: 'sales', component: SectionSalesComponent},
//     { path: 'orders', component: SectionOrdersComponent },
//     { path: 'health', component: SectionHealthComponent},

//     { path: '', redirectTo: '/sales', pathMatch: 'full' },
// ];