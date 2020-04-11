import { ProductPropertyValueComponent } from './member-ad/member-ad-edit/product-property-value/product-property-value.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MemberRoutingModule } from './member-routing.module';
import { NgModule } from '@angular/core';
import { MemberService } from './member.service';
import { MemberAdEditComponent } from './member-ad/member-ad-edit/member-ad-edit.component';

@NgModule({
  declarations: [
    ProductPropertyValueComponent,
    MemberAdEditComponent
  ],
  imports: [
    MemberRoutingModule,
    CommonModule,
    FormsModule,
  ],
  exports: [],
  providers: [
    MemberService
  ]
})


export class MemberModule { }
