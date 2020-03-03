import { AdStatus } from '../_enums/adStatus.enum';
import { CategoryModel } from './category.model';
import { ProductModel } from './product.model';
import { MemberModel } from './member.model';
import { PhotoModel } from './photo.model';

export interface AdModel {
  id?: string;
  title: string;
  description: string;
  adStatus: AdStatus;
  member: MemberModel;
  memberId: string;
  categoryId: string;
  category: CategoryModel;
  product: ProductModel;
  photos: PhotoModel[];
}


