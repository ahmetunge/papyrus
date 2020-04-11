import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap';
import { CommonModule } from '@angular/common';

import { AdListComponent } from './ad-list/ad-list.component';
import { AdRoutingModule } from './ad-routing.module';
import { AdItemComponent } from './ad-list/ad-item/ad-item.component';
import { AdService } from './ad.service';
import { CategoryService } from '../category/category.service';

import { AdEditResolver } from '../_resolvers/ad-edit-resolver';
import { AdDetailComponent } from './ad-detail/ad-detail.component';
import { AddStatusPipe } from '../_pipes/ad-status.pipe';
import { AdDetailResolver } from '../_resolvers/ad-detail-resolver';

@NgModule({
  declarations: [
    AdListComponent,
    AdItemComponent,
    AdDetailComponent,
    AddStatusPipe
  ],
  imports: [
    AdRoutingModule,
    CommonModule,
    FormsModule,
    TabsModule.forRoot()
  ],
  exports: [],
  providers: [
    AdService,
    CategoryService,
    AdEditResolver,
    AdDetailResolver
  ]
})

export class AdModule { }
