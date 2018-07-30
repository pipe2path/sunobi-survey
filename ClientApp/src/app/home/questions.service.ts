import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuestionsService {

  constructor(private http: HttpClient) { }

  configUrl = 'assets/config.json';

  getQuestionsByEntity(entityId: number) {
    var questions = this.http.get(this.configUrl);
    return questions;
  }
}
