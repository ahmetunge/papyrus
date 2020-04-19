import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../core/guards/auth.guard';
import { MemberAdEditComponent } from './member-ad/member-ad-edit/member-ad-edit.component';
import { AdEditResolver } from '../ad/resolvers/ad-edit-resolver';


const routes: Routes = [
  {
    path: 'member',
    children:
      [
        {
          path: 'ads/new',
          runGuardsAndResolvers: 'always',
          canActivate: [AuthGuard],
          component: MemberAdEditComponent,
          resolve: { categories: AdEditResolver }
        }
      ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
  providers: [
  ]
})

export class MemberRoutingModule { }
