import { AdStatus } from '../_enums/adStatus.enum';
import { ProductModel } from './product.model';
import { PhotoModel } from './photo.model';
import { KeyValueModel } from './keyValue.model';

export interface AdDetailModel {
  title: string;
  description: string;
  status: AdStatus;
  categoryName: string;
  productPropertyValues: any;
  photos: PhotoModel[];
}
