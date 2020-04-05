import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap';
import { CommonModule } from '@angular/common';

import { AdListComponent } from './ad-list/ad-list.component';
import { AdRoutingModule } from './ad-routing.module';
import { AdItemComponent } from './ad-list/ad-item/ad-item.component';
import { AdService } from './ad.service';
import { AdEditComponent } from './ad-edit/ad-edit.component';
import { CategoryService } from '../category/category.service';
import { ProductPropertyValueComponent } from './ad-edit/product-property-value/product-property-value.component';
import { AdEditResolver } from '../_resolvers/ad-edit-resolver';
import { AdDetailComponent } from './ad-detail/ad-detail.component';
import { AddStatusPipe } from '../_pipes/ad-status.pipe';

@NgModule({
  declarations: [
    AdListComponent,
    AdItemComponent,
    AdEditComponent,
    ProductPropertyValueComponent,
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
    AdEditResolver
  ]
})

export class AdModule { }
