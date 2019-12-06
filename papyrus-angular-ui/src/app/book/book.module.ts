import { NgModule } from '@angular/core';

import { BookListComponent } from './book-list/book-list.component';
import { BookService } from './book.service';
import { CommonModule } from '@angular/common';
import { BookRoutingModule } from './book-routing.module';
import { BookItemComponent } from './book-list/book-item/book-item.component';

@NgModule({
    declarations: [
        BookListComponent,
        BookItemComponent
    ],
    imports: [
        CommonModule,
        BookRoutingModule
    ],
    providers: [
        BookService
    ]
})

export class BookModule { }
