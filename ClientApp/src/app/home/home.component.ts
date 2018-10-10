import { Component, ViewChild } from '@angular/core';
import { QuestionsService } from './questions.service';
import { UserService } from './user.service';
import { Question } from './QuestionModel';
import { ResponseDetail } from './ResponseDetail';
import { Response } from './Response';
import { HttpHeaders } from '@angular/common/http';
import { ConfirmationModal } from './confirmation-modal';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [QuestionsService, UserService]
})

export class HomeComponent {
  //questions: Question[];  -- to be enabled when using mock questions
  public questions;
  public user;
  error: any;
  public responses: ResponseDetail[];
  public imageSrc = '../assets/headerLogo2.png';
  //@ViewChild('examplemodal')
  //private modalRef: ConfirmationModal;

  constructor(private questionsService: QuestionsService, private userService: UserService, private modalService: NgbModal) {
  }

  ngOnInit() {
    this.getQuestionsWeb();
    this.responses = [];
    this.name = '';
    this.phone = '';
    this.email = '';
    this.optIn = 0;
    //this.showConfirmationModal = false;
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
    this.responses.push(new ResponseDetail(surveyId, questionId, choiceId));
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

  optIn = 0;

  submitBtnState() {
    var btnState = false;
    if (this.optIn == 1 && this.responses.length > 0 && this.phone != '')
      btnState = true;

    return btnState;
  }

  getUserByPhone(phone: string): void {
    this.userService.getUserByPhone(phone).subscribe(
      data => { this.user = data },
      err => console.error(err),
      () => console.log('done loading user')
    );
  }

  showConfirmationModal = false;
  onSubmit() {

    // validate if phone number has been used before
    this.getUserByPhone(this.phone);
    if (this.user != undefined) {
      const modalRef = this.modalService.open(ConfirmationModal, { centered: true, size: 'sm' });
      modalRef.componentInstance.content = 'Sorry. Only 1 offer per phone number please';
      return;
    }
    var response = new Response(1, this.name, this.phone, this.email, this.optIn, this.responses);
    this.questionsService.saveResponse(response).subscribe(
      data => response = data)

    // display confirmation modal
    const modalRef = this.modalService.open(ConfirmationModal, { centered: true, size: 'sm' });
    modalRef.componentInstance.content = 'Thank you!';
    this.ngOnInit();
    
  }
}
