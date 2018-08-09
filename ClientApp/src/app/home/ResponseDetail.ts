export class ResponseDetail {
  public surveyId: number;
  public questionId: number;
  private choiceId: number;

  constructor(surveyId, questionId, choiceId) {
    this.surveyId = surveyId;
    this.questionId = questionId;
    this.choiceId = choiceId;
  }
}
