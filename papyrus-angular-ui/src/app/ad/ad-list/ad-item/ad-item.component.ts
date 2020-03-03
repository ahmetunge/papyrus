import { Component, Input, OnInit } from '@angular/core';
import { AdModel } from 'src/app/_models/ad.model';

@Component({
  selector: 'app-ad-item',
  templateUrl: './ad-item.component.html',
  styleUrls: ['./ad-item.component.css']
})
export class AdItemComponent implements OnInit {

  @Input() ad: AdModel;

  constructor() { }

  ngOnInit() {
  }

}
