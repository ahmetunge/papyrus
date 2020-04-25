import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AdService } from '../ad.service';
import { AuthService } from '../../core/services/auth.service';
import { catchError } from 'rxjs/operators';
import { ResponseModel } from 'src/app/_models/response.model';

@Injectable()

export class AdDetailResolver implements Resolve<ResponseModel> {

  constructor(
    private adService: AdService,
    private authService: AuthService,
    private router: Router
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<ResponseModel> {
    return this.adService.getAdDetail(this.authService.nameId, route.params.id).pipe(
      catchError(err => {
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }

}
