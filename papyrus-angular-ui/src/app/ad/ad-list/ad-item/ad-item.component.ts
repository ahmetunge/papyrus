import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { AdModel } from 'src/app/shared/models/ad.model';

@Component({
  selector: 'app-ad-item',
  templateUrl: './ad-item.component.html',
  styleUrls: ['./ad-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AdItemComponent implements OnInit {

  @Input() ad: AdModel;

  constructor() { }

  ngOnInit() {
  }

}
