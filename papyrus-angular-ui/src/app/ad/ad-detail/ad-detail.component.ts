import { Component, OnInit } from '@angular/core';
import { AdModel } from 'src/app/_models/ad.model';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-ad-detail',
  templateUrl: './ad-detail.component.html'
})

export class AdDetailComponent implements OnInit {

  ad: AdModel;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
   // this.getAdDetail();
  }

  // getAdDetail() {
  //   this.route.data.subscribe((response) => {
  //     this.ad = response.adDetailResolve.data;
  //   });
  // }

}
