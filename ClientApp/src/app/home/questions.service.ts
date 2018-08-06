import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Question } from './QuestionModel';
import { Response } from './ResponseModel';
import { QUESTIONS } from './mock-questions';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { environment } from '../../environments/environment';

@Injectable()
export class QuestionsService {

  constructor(private http: HttpClient) {
  }

  //getQuestionsUrl = 'http://sunobisurvey-env.ugwysmsubj.us-west-2.elasticbeanstalk.com/api/surveyquestions';
  //postResponseUrl = 'http://sunobisurvey-env.ugwysmsubj.us-west-2.elasticbeanstalk.com/api/surveyresponses';
  getQuestionsUrl = environment.apiUrl + "/surveyquestions";
  postResponseUrl = environment.apiUrl + "/surveyresponses/Create";

  getQuestionsByEntityMock(entityId: number): Observable<Question[]> {
    var questions = of(QUESTIONS);
    return questions;
  }

  getQuestionsByEntity(entityId: number) {
    var questions = this.http.get(this.getQuestionsUrl);
    return questions;
  }
  
  saveResponse(response: Response): Observable<boolean> {

    let httpHeaders = new HttpHeaders({
      'Content-Type' : 'application/json'
    })

    let options = {
      headers: httpHeaders
    };

    const body = JSON.stringify(response);

    return this.http.post<boolean>(this.postResponseUrl, body, options);
      
  }
}
