import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AdService } from '../ad/ad.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../_services/auth.service';
import { catchError } from 'rxjs/operators';
import { AdDetailModel } from '../_models/ad-detail.model';

@Injectable()

export class AdDetailResolver implements Resolve<AdDetailModel> {

  constructor(
    private adService: AdService,
    private toastr: ToastrService,
    private authService: AuthService,
    private router: Router
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<AdDetailModel> {
    return this.adService.getAdDetail(this.authService.nameId, route.params.id).pipe(
      catchError(err => {
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }

}
