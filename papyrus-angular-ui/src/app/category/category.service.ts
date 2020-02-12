import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { KeyValueModel } from '../_models/keyValueModel';
import { Category } from '../_models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategoriesForAd(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'categories/ad');
  }

}
