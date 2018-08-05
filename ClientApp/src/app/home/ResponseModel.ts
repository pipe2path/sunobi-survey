export class Response {
  public entityId: number;
  public questionId: number;
  private choiceId: number;

  constructor(entityId, questionId, choiceId) {
    this.entityId = entityId;
    this.questionId = questionId;
    this.choiceId = choiceId;
  }
}
