import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AdModel } from '../_models/ad.model';
import { AdService } from '../ad/ad.service';

@Injectable()
export class AdListResolver implements Resolve<AdModel> {

  constructor(
    private adService: AdService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<AdModel> {
    return this.adService.getAds().pipe(
      catchError(error => {
        this.toastr.error('Problem retrieving data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
