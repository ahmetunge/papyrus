import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../_guards/auth.guard';
import { BookListComponent } from './book-list/book-list.component';
import { BookListResolver } from '../_resolvers/book-list.resolver';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { BookDetailResolver } from '../_resolvers/book-detail.resolver';

const bookRoutes: Routes = [
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {
                path: 'books',
                component: BookListComponent,
                canActivate: [AuthGuard],
                resolve: { books: BookListResolver }
            },
            {
                path: 'books/:id',
                component: BookDetailComponent,
                canActivate: [AuthGuard],
                resolve: { book: BookDetailResolver }
            }
        ]
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(bookRoutes)
    ],
    exports: [RouterModule],
    providers: [
        BookListResolver,
        BookDetailResolver
    ]
})

export class BookRoutingModule { }
