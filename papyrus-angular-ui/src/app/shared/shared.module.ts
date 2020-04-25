import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AddStatusPipe } from './pipes/ad-status.pipe';
import { CategoryListResolver } from './resolvers/category-list.resolver';


@NgModule({
  declarations: [AddStatusPipe],
  imports: [CommonModule, FormsModule],
  exports: [CommonModule, FormsModule, AddStatusPipe],
  providers: [CategoryListResolver]
})

export class SharedModule {

}
