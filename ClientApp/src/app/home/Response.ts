import { ResponseDetail } from './ResponseDetail';

export class Response {
  public surveyId: number;
  public userName: string;
  public userPhone: string;
  public userEmail: string;
  public responseDetails: ResponseDetail[];

  constructor(surveyId, userName, userPhone, userEmail, responseDetail) {
    this.surveyId = surveyId;
    this.userName = userName;
    this.userPhone = userPhone;
    this.userEmail = userEmail;
    this.responseDetails = responseDetail
  }
}
