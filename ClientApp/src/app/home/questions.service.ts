import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Question } from './QuestionModel';
import { Response } from './ResponseModel';
import { QUESTIONS } from './mock-questions';
import { Observable } from 'rxjs/Observable';
import { HttpHeaders } from '@angular/common/http';
import { of } from 'rxjs/observable/of';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class QuestionsService {

  constructor(private http: HttpClient) { }

  getQuestionsUrl = 'http://sunobisurvey-env.ugwysmsubj.us-west-2.elasticbeanstalk.com/api/surveyquestions';
  postResponseUrl = 'http://sunobisurvey-env.ugwysmsubj.us-west-2.elasticbeanstalk.com/api/surveyresponses';

  getQuestionsByEntityMock(entityId: number): Observable<Question[]> {
    var questions = of(QUESTIONS);
    return questions;
  }

  getQuestionsByEntity(entityId: number) {
    var questions = this.http.get(this.getQuestionsUrl);
    return questions;
  }

  
  saveResponse(response: Response): Observable<Response> {
    return this.http.post<Response>(this.postResponseUrl, response, httpOptions);
      
  }

  


}
