export class Response {
  public questionId: number;
  private choiceId: number;

  constructor(questionId, choiceId) {
    this.questionId = questionId;
    this.choiceId = choiceId;
  }
}
