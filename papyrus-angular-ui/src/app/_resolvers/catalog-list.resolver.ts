import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Catalog } from '../_models/catalog';
import { CatalogCommonService } from '../_services/catalog-common.service';

@Injectable()
export class CatalogListResolver implements Resolve<Catalog> {

    constructor(
        private catalogCommonService: CatalogCommonService,
        private router: Router,
        private toastr: ToastrService
    ) { }

    resolve(route: ActivatedRouteSnapshot): Observable<Catalog> {
        return this.catalogCommonService.getCatalogs().pipe(
            catchError(error => {
                this.toastr.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
