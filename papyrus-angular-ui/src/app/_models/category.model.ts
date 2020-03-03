import { PropertyModel } from './property.model';

export interface CategoryModel {
  id: string;
  name: string;
  properties: PropertyModel[];
}
