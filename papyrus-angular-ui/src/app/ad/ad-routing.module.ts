import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdListComponent } from './ad-list/ad-list.component';
import { AdListResolver } from './resolvers/ad-list.resolver';
import { AdDetailComponent } from './ad-detail/ad-detail.component';
import { AdDetailResolver } from './resolvers/ad-detail-resolver';
import { AdEditComponent } from './ad-edit/ad-edit.component';
import { AdComponent } from './ad.component';
import { CategoryListResolver } from '../shared/resolvers/category-list.resolver';


const adRoutes: Routes = [
  {
    path: '',
    component: AdComponent,
    children:
      [
        {
          path: '',
          component: AdListComponent,
          resolve: { adListResolve: AdListResolver }
        },
        {
          path: 'new',
          component: AdEditComponent,
          resolve: { categoryListResolve: CategoryListResolver }
        },
        {
          path: ':id',
          component: AdDetailComponent,
          resolve: { adDetailResolve: AdDetailResolver }
        },

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
  providers: []
})

export class AdRoutingModule { }
