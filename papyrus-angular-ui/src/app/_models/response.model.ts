import { HttpStatusCode } from '../_enums/httpStatusCode.enum';

export interface ResponseModel {
  data: any;
  success: boolean;
  message: string;
  statusCode: HttpStatusCode;
}
