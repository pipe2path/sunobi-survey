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

  getQuestionsUrl = 'http://localhost:28094/api/surveyquestions';
  postResponseUrl = 'http://localhost:28094/api/surveyresponses';

  getQuestionsByEntityMock(entityId: number): Observable<Question[]> {
    var questions = of(QUESTIONS);
    return questions;
  }

  getQuestionsByEntity(entityId: number) {
    var questions = this.http.get(this.getQuestionsUrl);
    return questions;
  }

  
  saveResponse(response: Response): Observable<Response> {
    return this.http.post<Response>(this.postResponseUrl, response, httpOptions)
      .pipe(
        error => this.log("Error during saveResponse")
      )
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
    return throwError(
      'Something bad happened; please try again later.');
  };


}
