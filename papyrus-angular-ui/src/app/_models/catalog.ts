import { KeyValueModel } from './keyValueModel';

export interface Catalog {
  id: string;
  name: string;
  genres: KeyValueModel[];
}
