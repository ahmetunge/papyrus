import { AdModel } from './ad.model';
import { ProductPropertyValueModel } from './productPropertyValue.model';

export interface ProductModel {
  id: string;
  name: string;
  adId: string;
  ad: AdModel;
  productPropertyValues: ProductPropertyValueModel[];
}
