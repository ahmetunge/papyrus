import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Ad } from '../_models/ad';

@Injectable({
  providedIn: 'root'
})
export class AdService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAds(): Observable<Ad[]> {
    return this.http.get<Ad[]>(this.baseUrl + 'ads');
  }

}
