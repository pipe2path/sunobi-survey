import { Component } from '@angular/core';
import { QuestionsService } from './questions.service';
import { Question } from './QuestionModel';
import { Response } from './ResponseModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [QuestionsService]
})

export class HomeComponent {
  questions: Question[];
  error: any;
  responses: Response[] = [];

  constructor(private questionsService: QuestionsService) {
  }

  ngOnInit() {
    this.getQuestions();
  }

  getQuestions(): void {
    this.questionsService.getQuestionsByEntity(1)
      .subscribe(questions => this.questions = questions);
  }

  sourceGroup = ["Yelp Search", "Our Flyer", "From a colleague", "Online banner"];  

  addResponse(questionId, choiceId): void {
    for (var i = 0; i < this.responses.length; i++) {
        if (this.responses[i].questionId == questionId) {
          this.responses.splice(i, 1);
        }
    }
    this.responses.push(new Response(questionId, choiceId));
  }


  active: number;
  onClick(questionIndex: number, choiceIndex: number) {

    this.addResponse(questionIndex, choiceIndex);
    
    //this.responses.push(new Response(questionIndex, choiceIndex))

    this.questions[questionIndex].activeChoice = choiceIndex;



  }

}
