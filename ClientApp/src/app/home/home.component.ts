import { Component } from '@angular/core';
import { QuestionsService } from './questions.service';
import { Question } from './QuestionModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [QuestionsService]
})

export class HomeComponent {
  questions: Question[];
  error: any;

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

  
  active: number;
  onClick(index: number) {
    this.active = index;
  }

}
