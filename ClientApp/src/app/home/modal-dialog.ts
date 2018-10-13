import { Component, Input, OnInit } from '@angular/core';

import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'modal-dialog',
  templateUrl: './modal-dialog.html'
})

export class ModalDialog implements OnInit {
  @Input() content;
  @Input() type;

  constructor(public activeModal: NgbActiveModal) {
  }

  ngOnInit() { }

}
