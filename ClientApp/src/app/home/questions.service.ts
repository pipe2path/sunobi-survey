import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuestionsService {

  constructor(private http: HttpClient) { }

  configUrl = 'http://localhost:44301/api/surveyquestions';

  getQuestionsByEntity(entityId: number) {
    var questions = this.http.get(this.configUrl);
    return questions;
  }
}
