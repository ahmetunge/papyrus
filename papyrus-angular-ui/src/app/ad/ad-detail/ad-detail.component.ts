import { Component, OnInit } from '@angular/core';
import { AdModel } from 'src/app/_models/ad.model';
import { ActivatedRoute } from '@angular/router';
import { AdStatus } from 'src/app/_enums/adStatus.enum';
import { AdDetailModel } from 'src/app/_models/ad-detail.model';


@Component({
  selector: 'app-ad-detail',
  templateUrl: './ad-detail.component.html'
})

export class AdDetailComponent implements OnInit {

  ad: AdDetailModel;


  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getAdDetail();
  }

  getAdDetail() {
    this.route.data.subscribe((response) => {
      this.ad = response.adDetailResolve.data;
    });
  }

}
