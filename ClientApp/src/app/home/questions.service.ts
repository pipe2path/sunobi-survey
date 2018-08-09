import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Question } from './QuestionModel';
import { Response } from './Response';
import { QUESTIONS } from './mock-questions';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { environment } from '../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class QuestionsService {

  constructor(private http: HttpClient) {
  }

  //getQuestionsUrl = 'http://sunobisurvey-env.ugwysmsubj.us-west-2.elasticbeanstalk.com/api/surveyquestions';
  //postResponseUrl = 'http://sunobisurvey-env.ugwysmsubj.us-west-2.elasticbeanstalk.com/api/surveyresponses';
  getQuestionsUrl = environment.apiUrl + "/questions";
  postResponseUrl = environment.apiUrl + "/responses";

  getQuestionsByEntityMock(entityId: number): Observable<Question[]> {
    var questions = of(QUESTIONS);
    return questions;
  }

  getQuestionsByEntity(entityId: number) {
    var questions = this.http.get(this.getQuestionsUrl);
    return questions;
  }

  //saveResponse(response: Response, name: string, phone: string, email: string): Observable<any> {
  //  const body = JSON.stringify(response);
  //  return this.http.post(this.postResponseUrl, body, httpOptions)
  //    .pipe(catchError(this.handleError));
  //}

  saveResponse(response: Response) {
    const body = JSON.stringify(response);
    return this.http.post(this.postResponseUrl, body, httpOptions)
        .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return 'Something bad happened; please try again later.';
  }
}
