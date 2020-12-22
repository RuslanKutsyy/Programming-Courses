import { Routes } from '@angular/router';
import { SectionSalesComponent } from "./app/Components/sections/section-sales/section-sales.component";
import { SectionOrdersComponent } from "./app/Components/sections/section-orders/section-orders.component";
import { SectionHealthComponent } from "./app/Components/sections/section-health/section-health.component";

export const appRoutes: Routes = [
    { path: 'sales', component: SectionSalesComponent},
    { path: 'orders', component: SectionOrdersComponent },
    { path: 'health', component: SectionHealthComponent},

    { path: '', redirectTo: '/sales', pathMatch: 'full' },
];