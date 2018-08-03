import { ChoiceModel } from './ChoiceModel';

export class Question {
  internalId: string;
  entityId: number;
  questionId: number;
  questionDesc: string;
  questionType: string;
  choices: string[];

  constructor(internalId, entityId, questionId, questionDesc, questionType, choices) {
    this.internalId = internalId;
    this.entityId = entityId;
    this.questionId = questionId;
    this.questionDesc = questionDesc;
    this.questionType = questionType;
    this.choices = choices;
  }

}
