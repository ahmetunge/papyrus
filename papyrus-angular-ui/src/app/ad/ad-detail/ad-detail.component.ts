import { Component, OnInit } from '@angular/core';
import { AdModel } from 'src/app/_models/ad.model';
import { ActivatedRoute } from '@angular/router';
import { AdStatus } from 'src/app/_enums/adStatus.enum';


@Component({
  selector: 'app-ad-detail',
  templateUrl: './ad-detail.component.html'
})

export class AdDetailComponent implements OnInit {

  ad: AdModel = {
    title: 'Title',
    // tslint:disable-next-line:max-line-length
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pellentesque turpis sed orci luctus tempor. In ut tempor est, eu convallis purus. Sed vitae nibh erat. Integer fermentum, lacus et tristique bibendum, eros eros pellentesque leo, dignissim commodo ante massa non libero. Nunc non urna vitae tellus pulvinar consequat sed sed sem. Nunc condimentum imperdiet nisi sed placerat. Pellentesque a aliquam purus. Donec viverra felis id nunc bibendum, ut finibus nulla consectetur. Donec quam lacus, facilisis nec rutrum at, dapibus eu nisi. Proin elit lectus, iaculis a nulla nec, sodales efficitur quam. Aenean congue dolor neque, id molestie nibh luctus non. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Cras sed fringilla arcu. Donec consectetur tincidunt odio, vel dictum lectus porttitor at.',
    status: AdStatus.Active,
    member: null,
    memberId: '',
    categoryId: '',
    category: {
      id: '',
      name: 'Category name',
      properties: [],
      ads: [],
    },
    product: {
      id: '',
      name: 'ProductName',
      adId: '',
      ad: null,
      productPropertyValues: []
    },
    photos: []
  };

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
