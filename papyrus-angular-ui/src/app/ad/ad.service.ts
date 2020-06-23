import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { ResponseModel } from '../shared/models/response.model';

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

}
