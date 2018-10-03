import { Component } from '@angular/core';

import { NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'terms-and-conditions-modal',
  templateUrl: './termsAndConditions-modal.html'
})
export class TermsAndConditionsModal {
  closeResult: string;
  termsAndConditions: string;
  modalRef;

  constructor(private modalService: NgbModal) { }

  open(content) {
    this.modalRef = this.modalService.open(content, { centered: true });
    this.modalRef.result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  onClose() {
    this.modalRef.close();
  }
  

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
