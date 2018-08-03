import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Question } from './QuestionModel';
import { QUESTIONS } from './mock-questions';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

@Injectable()
export class QuestionsService {

  constructor(private http: HttpClient) { }

  configUrl = 'http://localhost:44301/api/surveyquestions';

  getQuestionsByEntity(entityId: number): Observable<Question[]> {
    //var questions = this.http.get(this.configUrl);
    var questions = of(QUESTIONS);
    return questions;
  }
}
