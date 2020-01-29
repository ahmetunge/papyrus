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

  ads: Ad[] = [
    {
      id: 'id-1',
      title: 'Ad-1',
      // tslint:disable-next-line:max-line-length
      description: 'Vestibulum vestibulum mi orci, at dignissim ligula consequat et. Aliquam ut ipsum aliquet, luctus urna sed, ultrices justo. Curabitur vel orci et turpis rhoncus blandit a sit amet tellus. Curabitur eleifend vulputate accumsan. Nullam nec justo risus. Pellentesque quis molestie lacus. Nunc vitae convallis leo, eu aliquam sapien.'
    },
    {
      id: 'id-2',
      title: 'Ad-2',
      // tslint:disable-next-line:max-line-length
      description: 'Nunc consequat ligula leo, ac interdum enim rutrum at. Pellentesque nec sem scelerisque velit cursus blandit ac vitae ipsum. Vestibulum maximus volutpat lobortis. Aliquam malesuada bibendum risus vel ultrices. Duis egestas eu mauris ut accumsan. Integer molestie enim id lectus hendrerit, sed cursus diam ultricies. Etiam non rhoncus elit. Duis tempor sodales aliquam.'
    },
    {
      id: 'id-3',
      title: 'Ad-3',
      // tslint:disable-next-line:max-line-length
      description: 'Vestibulum finibus vestibulum lectus sed fermentum. Quisque malesuada, tellus ut scelerisque cursus, nunc leo luctus ipsum, vel faucibus tortor eros eu justo. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam ut scelerisque arcu. Donec imperdiet quam non nisi blandit sagittis. Sed quam metus, fringilla at est et, vestibulum pulvinar nunc. Mauris dapibus blandit tempus.'
    },
    {
      id: 'id-4',
      title: 'Ad-4',
      // tslint:disable-next-line:max-line-length
      description: 'Aenean at neque ultrices, lacinia ligula in, laoreet purus. Nulla lacinia sagittis arcu a sollicitudin. Fusce rutrum sem libero. Vestibulum in diam in libero dapibus consequat. Pellentesque iaculis iaculis sem vitae eleifend. Mauris vel suscipit justo. In a dapibus ex, in tincidunt sem. Mauris euismod luctus diam sit amet blandit.'
    },
    {
      id: 'id-3',
      title: 'Ad-5',
      // tslint:disable-next-line:max-line-length
      description: 'Cras lorem ligula, iaculis nec fermentum eu, vulputate eget sem. Nullam nunc dolor, facilisis eu vulputate nec, elementum dictum sem. Cras at augue turpis. Pellentesque malesuada accumsan arcu vitae convallis. Nunc sapien nunc, facilisis vel enim at, pharetra tincidunt orci. Aliquam et nisl mauris. Cras et elit erat. '
    }
  ];

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
