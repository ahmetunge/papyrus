import { ProductModel } from './product.model';
import { PropertyModel } from './property.model';

export interface ProductPropertyValueModelodel {
  product: ProductModel;
  productId: string;
  propertyId: string;
  property: PropertyModel;
  value: string;
}

