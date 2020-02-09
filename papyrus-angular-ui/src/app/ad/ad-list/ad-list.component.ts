import { Component, OnInit } from '@angular/core';
import { Ad } from 'src/app/_models/ad';
import { AdService } from '../ad.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ad-list',
  templateUrl: './ad-list.component.html',
  styleUrls: ['./ad-list.component.css']
})
export class AdListComponent implements OnInit {

  ads: Ad[] = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getAds();
  }

  getAds() {
    this.route.data.subscribe(data => {
      this.ads = data.ads;
    });
  }

}
