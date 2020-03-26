import { Component, OnInit } from '@angular/core';
import { AdModel } from 'src/app/_models/ad.model';
import { AdService } from '../ad.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ad-list',
  templateUrl: './ad-list.component.html',
  styleUrls: ['./ad-list.component.css']
})
export class AdListComponent implements OnInit {

  ads: AdModel[] = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getAds();
  }

  getAds() {
    this.route.data.subscribe(response => {
      this.ads = response.adListResolve.data;
      debugger;
    });
  }

}
