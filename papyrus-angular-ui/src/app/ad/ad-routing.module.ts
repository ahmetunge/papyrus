import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdListComponent } from './ad-list/ad-list.component';
import { AdListResolver } from '../_resolvers/ad-list.resolver';

const adRoutes: Routes = [
  {
    path: '',
    children:
      [
        {
          path: 'ads',
          component: AdListComponent,
          resolve: { ads: AdListResolver }
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
