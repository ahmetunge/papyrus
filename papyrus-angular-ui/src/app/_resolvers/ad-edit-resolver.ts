import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';
import { AdModel } from '../_models/ad.model';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from '../category/category.service';


@Injectable()

export class AdEditResolver implements Resolve<AdModel> {

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private authService: AuthService,
    private categoryService: CategoryService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<AdModel> {
    return this.categoryService.getCategoriesForAd().pipe(
      catchError(error => {
        this.toastr.error('Problem retrieving your data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }

}




