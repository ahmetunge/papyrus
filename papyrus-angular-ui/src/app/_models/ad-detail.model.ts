import { AdStatus } from '../_enums/adStatus.enum';
import { ProductModel } from './product.model';
import { PhotoModel } from './photo.model';

export interface AdDetailModel {
  title: string;
  description: string;
  status: AdStatus;
  categoryName: string;
  product: ProductModel;
  photos: PhotoModel[];
}
