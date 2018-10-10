import { Component, Input, OnInit } from '@angular/core';

import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'confirmation-modal',
  templateUrl: './confirmation-modal.html'
})

export class ConfirmationModal implements OnInit {
  @Input() content;
  
  constructor(public activeModal: NgbActiveModal) {
  }

  ngOnInit() { }
  
}
