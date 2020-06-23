import { HttpStatusCode } from '../enums/httpStatusCode.enum';

export interface ResponseModel {
  data: any;
  success: boolean;
  message: string;
  statusCode: HttpStatusCode;
}
