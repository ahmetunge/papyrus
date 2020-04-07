import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { AdModel } from '../_models/ad.model';
import { ResponseModel } from '../_models/response.model';

@Injectable({
  providedIn: 'root'
})
export class AdService {

  baseUrl = environment.apiUrl;


  constructor(private http: HttpClient) { }

  getAds(memberId: string): Observable<ResponseModel> {
    return this.http.get<ResponseModel>(this.baseUrl + 'members/' + memberId + '/ads');
  }

  addAd(memberId: string, ad: AdModel) {
    return this.http.post(this.baseUrl + 'members/' + memberId + '/ads', ad);
  }

  getAdDetail(memberId: string, adId: string): Observable<ResponseModel> {
    return this.http.get<ResponseModel>(this.baseUrl + 'members/' + memberId + '/ads/' + adId);
  }

}
