import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Book } from '../_models/book';
import { BookService } from '../book/book.service';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Ad } from '../_models/ad';
import { AdService } from '../ad/ad.service';

@Injectable()
export class AdListResolver implements Resolve<Ad> {

  constructor(
    private adService: AdService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<Ad> {
    return this.adService.getAds().pipe(
      catchError(error => {
        this.toastr.error('Problem retrieving data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
