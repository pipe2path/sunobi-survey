import { Component } from '@angular/core';

import { NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'terms-and-conditions-modal',
  templateUrl: './termsAndConditions-modal.html'
})
export class TermsAndConditionsModal {
  closeResult: string;
   modalRef;

  constructor(private modalService: NgbModal) { }

  termsAndConditions = 'As a condition to receive our offer, you agree to receive a text message on your phone number, not more than 4 times a month. Your name, email and phone number ' +
    'will never be shared or sold to a third-party. Please call our store to opt out. This policy may be amended from time to time. Any amendments to our privacy policy will ' +
    'be posted as a notification on our homepage http://winzza.com';

  open(content) {
    this.modalRef = this.modalService.open(content, { centered: true, size: 'sm' });
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
