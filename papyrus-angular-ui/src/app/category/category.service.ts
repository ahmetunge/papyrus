import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { KeyValueModel } from '../_models/keyValueModel';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategoriesForAd(): Observable<KeyValueModel[]> {
    return this.http.get<KeyValueModel[]>(this.baseUrl + 'categories/ad');
  }

}
