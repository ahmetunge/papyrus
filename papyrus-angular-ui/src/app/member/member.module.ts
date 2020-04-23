
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
// import { MemberRoutingModule } from './member-routing.module';
import { NgModule } from '@angular/core';
import { MemberService } from './member.service';


@NgModule({
  declarations: [
  ],
  imports: [
   // MemberRoutingModule,
    CommonModule,
    FormsModule,
  ],
  exports: [],
  providers: [
    MemberService
  ]
})


export class MemberModule { }
