import { NgModule } from '@angular/core';
import { HomeComponent } from './home.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [SharedModule],
  declarations: [HomeComponent],
  exports: [],
  providers: []
})

export class HomeModule {

}
