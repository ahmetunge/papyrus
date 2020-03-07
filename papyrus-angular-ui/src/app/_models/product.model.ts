import { AdModel } from './ad.model';
import { ProductPropertyValueModel } from './productPropertyValue.model';

export interface ProductModel {
  id: string;
  adId: string;
  ad: AdModel;
  productPropertyValues: ProductPropertyValueModel[];
}
