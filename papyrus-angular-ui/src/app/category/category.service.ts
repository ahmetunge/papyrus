import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryModel } from '../_models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategoriesForAd(): Observable<CategoryModel[]> {
    return this.http.get<CategoryModel[]>(this.baseUrl + 'categories/ad');
  }

}
