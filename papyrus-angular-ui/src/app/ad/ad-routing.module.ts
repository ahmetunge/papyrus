import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdListComponent } from './ad-list/ad-list.component';
import { AdListResolver } from './resolvers/ad-list.resolver';
import { AdDetailComponent } from './ad-detail/ad-detail.component';
import { AdDetailResolver } from './resolvers/ad-detail-resolver';
import { AdEditComponent } from './ad-edit/ad-edit.component';


const adRoutes: Routes = [
  {
    path: 'ads',
    children:
      [
        {
          path: 'new',
          component: AdEditComponent,

        },
        {
          path: '',
          component: AdListComponent,
          resolve: { adListResolve: AdListResolver }
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
  providers: [
    AdListResolver
  ]
})

export class AdRoutingModule { }
