import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { AdModel } from '../_models/ad.model';
import { ProductPropertyValueModelodel } from '../_models/productPropertyValue.model';

@Injectable({
  providedIn: 'root'
})
export class AdService {

  baseUrl = environment.apiUrl;
  propertyValuesSubject = new BehaviorSubject<ProductPropertyValueModelodel[]>([]);

  propertyValues = this.propertyValuesSubject.asObservable();


  constructor(private http: HttpClient) { }

  getAds(): Observable<AdModel[]> {
    return this.http.get<AdModel[]>(this.baseUrl + 'ads');
  }

  addAd(ad: AdModel) {
    return this.http.post(this.baseUrl + 'ads', ad);
  }

  onPropertyValueChange(propertyValues: ProductPropertyValueModelodel[]) {
    this.propertyValuesSubject.next(propertyValues);
  }

}
