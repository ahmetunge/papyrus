import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';


import { AuthService } from '../../core/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from 'src/app/category/category.service';
import { ResponseModel } from 'src/app/shared/models/response.model';

@Injectable()
export class CategoryListResolver implements Resolve<ResponseModel> {
  constructor(
    private router: Router,
    private toastr: ToastrService,
    private authService: AuthService,
    private categoryService: CategoryService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<ResponseModel> {
    return this.categoryService.getCategoriesForAd().pipe(
      catchError(error => {
        this.toastr.error('Problem retrieving your data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }

}

