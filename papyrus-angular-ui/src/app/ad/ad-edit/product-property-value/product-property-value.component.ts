import { Component, OnInit, Input } from '@angular/core';
import { Property } from 'src/app/_models/property';

@Component({
  selector: 'app-product-property-value',
  templateUrl: './product-property-value.component.html',
  styleUrls: ['./product-property-value.component.css']
})
export class ProductPropertyValueComponent implements OnInit {

   @Input() property: Property;

  constructor() { }

  ngOnInit() {
  }

}
