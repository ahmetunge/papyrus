import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
