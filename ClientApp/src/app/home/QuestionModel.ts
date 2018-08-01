import { ChoiceModel } from './ChoiceModel';

export class QuestionModel {
  private internalId: string;
  private id: number;
  private desc: string;
  private choices: string[];

  constructor(internalId, id, desc, choices) {
    this.internalId = internalId;
    this.id = id;
    this.desc = desc;
    this.choices = choices;
  }

}
