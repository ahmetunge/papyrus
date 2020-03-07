import { Component, OnInit, Input } from '@angular/core';
import { PropertyModel } from 'src/app/_models/property.model';
import { PropertyType } from 'src/app/_enums/PropertyType.enum';
import { ProductPropertyValueModel } from 'src/app/_models/productPropertyValue.model';


@Component({
  selector: 'app-product-property-value',
  templateUrl: './product-property-value.component.html',
  styleUrls: ['./product-property-value.component.css']
})
export class ProductPropertyValueComponent implements OnInit {

  @Input() productPropertyValues: ProductPropertyValueModel[];
  public value: ProductPropertyValueComponent[];
  propertyType: typeof PropertyType = PropertyType;

  constructor() { }

  ngOnInit() {
  }

}
