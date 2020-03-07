import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdListComponent } from './ad-list/ad-list.component';
import { AdListResolver } from '../_resolvers/ad-list.resolver';
import { AdEditComponent } from './ad-edit/ad-edit.component';
import { AdEditResolver } from '../_resolvers/ad-edit-resolver';

const adRoutes: Routes = [
  {
    path: '',
    children:
      [
        {
          path: 'ads',
          component: AdListComponent,
          resolve: { ads: AdListResolver }
        },
        {
          path: 'ads/new',
          component: AdEditComponent,
          resolve: { categories: AdEditResolver }
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
