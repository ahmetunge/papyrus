import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AdModel } from '../_models/ad.model';

@Injectable({
  providedIn: 'root'
})
export class AdService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAds(): Observable<AdModel[]> {
    return this.http.get<AdModel[]>(this.baseUrl + 'ads');
  }

  addAd(ad: AdModel) {
    return this.http.post(this.baseUrl + 'ads', ad);
  }

}
