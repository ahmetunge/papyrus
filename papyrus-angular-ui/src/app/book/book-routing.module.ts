import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../_guards/auth.guard';
import { BookListComponent } from './book-list/book-list.component';
import { BookListResolver } from '../_resolvers/book-list.resolver';

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
        ]
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(bookRoutes)
    ],
    exports: [RouterModule],
    providers: [
        BookListResolver
    ]
})

export class BookRoutingModule { }
