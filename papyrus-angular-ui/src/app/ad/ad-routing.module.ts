import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdListComponent } from './ad-list/ad-list.component';
import { AdListResolver } from '../_resolvers/ad-list.resolver';
import { AdDetailComponent } from './ad-detail/ad-detail.component';
import { AdDetailResolver } from '../_resolvers/ad-detail-resolver';


const adRoutes: Routes = [
  {
    path: '',
    children:
      [
        {
          path: 'ads',
          component: AdListComponent,
          resolve: { adListResolve: AdListResolver }
        },
        {
          path: 'ads/:id',
          component: AdDetailComponent,
          resolve: { adDetailResolve: AdDetailResolver }
        }
      ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(adRoutes)
  ],
  exports: [
    RouterModule
  ],
  providers: [
    AdListResolver
  ]
})

export class AdRoutingModule { }
