import { Component, Input, OnInit } from '@angular/core';
import { Ad } from 'src/app/_models/ad';

@Component({
  selector: 'app-ad-item',
  templateUrl: './ad-item.component.html',
  styleUrls: ['./ad-item.component.css']
})
export class AdItemComponent implements OnInit {

  @Input() ad: Ad;

  constructor() { }

  ngOnInit() {
  }

}
