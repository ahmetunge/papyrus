import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { AdModel } from 'src/app/shared/models/ad.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ad-item',
  templateUrl: './ad-item.component.html',
  styleUrls: ['./ad-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AdItemComponent implements OnInit {

  @Input() ad: AdModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit() {
  }

  onEditAd(id: any) {
    this.router.navigate([id, 'edit'], { relativeTo: this.route });
  }

}
