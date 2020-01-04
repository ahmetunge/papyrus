import { NgModule } from '@angular/core';
import {TabsModule} from 'ngx-bootstrap';

import { BookListComponent } from './book-list/book-list.component';
import { BookService } from './book.service';
import { CommonModule } from '@angular/common';
import { BookRoutingModule } from './book-routing.module';
import { BookItemComponent } from './book-list/book-item/book-item.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { BookEditComponent } from './book-edit/book-edit.component';
import { FormsModule } from '@angular/forms';
import { CatalogGenreListComponent } from '../catalog-genre-list/catalog-genre-list.component';

@NgModule({
    declarations: [
        BookListComponent,
        BookItemComponent,
        BookDetailComponent,
        BookEditComponent,
        CatalogGenreListComponent
    ],
    imports: [
        CommonModule,
        BookRoutingModule,
        TabsModule.forRoot(),
        FormsModule
    ],
    providers: [
        BookService
    ]
})

export class BookModule { }
