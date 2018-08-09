import { Component } from '@angular/core';
import { QuestionsService } from './questions.service';
import { Question } from './QuestionModel';
import { Response } from './ResponseModel';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [QuestionsService]
})

export class HomeComponent {
  //questions: Question[];  -- to be enabled when using mock questions
  public questions;
  error: any;
  public responses: Response[] = [];
  public imageSrc = '../assets/headerLogo2.png';

  constructor(private questionsService: QuestionsService) {
  }

  ngOnInit() {
    this.getQuestionsWeb();
  }

  getQuestionsMock(): void {
    this.questionsService.getQuestionsByEntityMock(1)
      .subscribe(questions => this.questions = questions);
  }

  getQuestionsWeb(): void {
    this.questionsService.getQuestionsByEntity(1).subscribe(
      data => { this.questions = data },
      err => console.error(err),
      () => console.log('done loading questions')
    );
  }

  //sourceGroup = ["Yelp Search", "Our Flyer", "From a colleague", "Online banner"];  

  addResponse(surveyId, questionId, choiceId): void {
    for (var i = 0; i < this.responses.length; i++) {
        if (this.responses[i].questionId == questionId) {
          this.responses.splice(i, 1);
        }
    }
    this.responses.push(new Response(surveyId, questionId, choiceId));
  }
  
  active: number;
  onClick(questionIndex: number, choiceIndex: number) {
    this.addResponse(1, questionIndex, choiceIndex);        // entityId is hard coded, need to change later
    this.questions[questionIndex].activeChoice = choiceIndex;
  }

  name = '';
  getName(value: string) {
    this.name = value;
  }

  phone = '';
  getPhone(value: string) {
    this.phone = value;
  }

  email = '';
  getEmail(value: string) {
    this.email = value;
  }
  
  onSave() {
    for (var i = 0; i < this.responses.length; i++) {
      var r = this.responses[i];
      this.questionsService.saveResponse(r, this.name, this.phone, this.email).subscribe(
        data => this.responses = data);
    }
    
  }

}
