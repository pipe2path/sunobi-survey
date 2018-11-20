export class ResponseDetail {
  public surveyId: number;
  public questionId: number;
  private choice: string;

  constructor(surveyId, questionId, choice) {
    this.surveyId = surveyId;
    this.questionId = questionId;
    this.choice = choice;
  }
}
