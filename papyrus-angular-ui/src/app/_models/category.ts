import { Property } from './property';

export interface Category {
  id: string;
  name: string;
  properties: Property[];
}
