import { NgModule } from '@angular/core';
import { AdListComponent } from './ad-list/ad-list.component';
import { AdRoutingModule } from './ad-routing.module';
import { AdItemComponent } from './ad-list/ad-item/ad-item.component';
import { CommonModule } from '@angular/common';
import { AdService } from './ad.service';
import { AdEditComponent } from './ad-edit/ad-edit.component';
import { CategoryService } from '../category/category.service';

@NgModule({
  declarations: [
    AdListComponent,
    AdItemComponent,
    AdEditComponent
  ],
  imports: [
    AdRoutingModule,
    CommonModule
  ],
  exports: [],
  providers: [
    AdService,
    CategoryService
  ]
})

export class AdModule { }
