import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { ResponseModel } from '../shared/models/response.model';
import { AdModel } from '../shared/models/ad.model';

@Injectable({
  providedIn: 'root'
})
export class AdService {

  baseUrl = environment.apiUrl;


  constructor(private http: HttpClient) { }

  getAds(memberId: string): Observable<ResponseModel> {
    return this.http.get<ResponseModel>(this.baseUrl + 'ads');
  }

  getAdDetail(memberId: string, adId: string): Observable<ResponseModel> {
    return this.http.get<ResponseModel>(this.baseUrl + 'ads/' + adId);
  }

  getAdDetailForEdit(memberId: string, adId: string): Observable<ResponseModel> {
    return this.http.get<ResponseModel>(this.baseUrl + 'members/' + memberId + '/ads/' + adId + '/edit');
  }

  addAd(memberId: string, ad: AdModel) {
    return this.http.post(this.baseUrl + 'members/' + memberId + '/ads', ad);
  }

  editAd(memberId: string, adId: string, ad: AdModel) {
    return this.http.put(this.baseUrl + 'members/' + memberId + '/ads/' + adId, ad);
  }

}
