import { Component, OnInit, Input } from '@angular/core';
import { Property } from 'src/app/_models/property';
import { PropertyType } from 'src/app/_models/PropertyType.enum';

@Component({
  selector: 'app-product-property-value',
  templateUrl: './product-property-value.component.html',
  styleUrls: ['./product-property-value.component.css']
})
export class ProductPropertyValueComponent implements OnInit {

  @Input() property: Property;
  propertyType: typeof PropertyType = PropertyType;

  constructor() { }

  ngOnInit() {
  }

}
