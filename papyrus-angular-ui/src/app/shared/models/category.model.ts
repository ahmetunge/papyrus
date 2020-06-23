import { PropertyModel } from './property.model';
import { AdModel } from './ad.model';

export interface CategoryModel {
  id: string;
  name: string;
  properties: PropertyModel[];
  ads: AdModel[];
}

