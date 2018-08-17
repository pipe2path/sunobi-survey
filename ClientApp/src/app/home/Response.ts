import { ResponseDetail } from './ResponseDetail';

export class Response {
  public surveyId: number;
  public userName: string;
  public userPhone: string;
  public userEmail: string;
  public optIn: number;
  public responseDetails: ResponseDetail[];

  constructor(surveyId, userName, userPhone, userEmail, optIn, responseDetail) {
    this.surveyId = surveyId;
    this.userName = userName;
    this.userPhone = userPhone;
    this.userEmail = userEmail;
    this.optIn = optIn;
    this.responseDetails = responseDetail
  }
}
