import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AdModel } from 'src/app/shared/models/ad.model';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  addAd(memberId: string, ad: AdModel) {
    return this.http.post(this.baseUrl + 'members/' + memberId + '/ads', ad);
  }

}
