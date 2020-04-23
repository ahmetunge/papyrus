
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap';

import { AdListComponent } from './ad-list/ad-list.component';
import { AdRoutingModule } from './ad-routing.module';
import { AdItemComponent } from './ad-list/ad-item/ad-item.component';
import { AdService } from './ad.service';
import { CategoryService } from '../category/category.service';

import { AdEditResolver } from './resolvers/ad-edit-resolver';
import { AdDetailComponent } from './ad-detail/ad-detail.component';
import { AdDetailResolver } from './resolvers/ad-detail-resolver';
import { SharedModule } from '../shared/shared.module';
import { ProductPropertyValueComponent } from './product-property-value/product-property-value.component';
import { AdEditComponent } from './ad-edit/ad-edit.component';

@NgModule({
  declarations: [
    AdListComponent,
    AdItemComponent,
    AdDetailComponent,
    ProductPropertyValueComponent,
    AdEditComponent
  ],
  imports: [
    AdRoutingModule,
    TabsModule.forRoot(),
    SharedModule
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
