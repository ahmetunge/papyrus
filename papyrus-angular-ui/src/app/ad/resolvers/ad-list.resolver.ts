import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AdService } from '../ad.service';
import { AuthService } from '../../core/services/auth.service';
import { ResponseModel } from 'src/app/_models/response.model';

@Injectable()
export class AdListResolver implements Resolve<ResponseModel> {

  constructor(
    private adService: AdService,
    private router: Router,
    private toastr: ToastrService,
    private authService: AuthService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<ResponseModel> {
    return this.adService.getAds(this.authService.nameId).pipe(
      catchError(error => {
       // this.toastr.error('Problem retrieving data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
