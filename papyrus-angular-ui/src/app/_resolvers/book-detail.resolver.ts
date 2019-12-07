import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Book } from '../_models/book';
import { Observable, of } from 'rxjs';
import { BookService } from '../book/book.service';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';

@Injectable()
export class BookDetailResolver implements Resolve<Book> {
    constructor(
        private bookService: BookService,
        private router: Router,
        private toaster: ToastrService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<Book> {
        return this.bookService.getBook(route.params.id).pipe(
            catchError(error => {
                this.toaster.error('Problem retrieving  data');
                this.router.navigate(['/books']);
                return of(null);
            })
        );
    }
}
