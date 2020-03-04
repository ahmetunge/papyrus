import { UserModel } from './user.model';
import { AdModel } from './ad.model';

export interface MemberModel {
  id: string;
  userId: string;
  user: UserModel;
  ads: AdModel[];
}

