import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Catalog } from '../_models/catalog';

@Injectable({
  providedIn: 'root'
})
export class CatalogCommonService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCatalogs(): Observable<Catalog[]> {
    return this.http.get<Catalog[]>(this.baseUrl + 'catalogs');
  }
}
