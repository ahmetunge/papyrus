import { NgModule } from '@angular/core';
import { AdListComponent } from './ad-list/ad-list.component';
import { AdRoutingModule } from './ad-routing.module';
import { AdItemComponent } from './ad-list/ad-item/ad-item.component';
import { CommonModule } from '@angular/common';
import { AdService } from './ad.service';
import { AdEditComponent } from './ad-edit/ad-edit.component';
import { CategoryService } from '../category/category.service';
import { FormsModule } from '@angular/forms';
import { ProductPropertyValueComponent } from './ad-edit/product-property-value/product-property-value.component';
import { AdEditResolver } from '../_resolvers/ad-edit-resolver';

@NgModule({
  declarations: [
    AdListComponent,
    AdItemComponent,
    AdEditComponent,
    ProductPropertyValueComponent
  ],
  imports: [
    AdRoutingModule,
    CommonModule,
    FormsModule
  ],
  exports: [],
  providers: [
    AdService,
    CategoryService,
    AdEditResolver
  ]
})

export class AdModule { }
