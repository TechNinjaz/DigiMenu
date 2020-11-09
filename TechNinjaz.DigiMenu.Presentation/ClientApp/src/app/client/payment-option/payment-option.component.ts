import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-payment-option',
  templateUrl: './payment-option.component.html',
  styleUrls: ['./payment-option.component.scss']
})
export class PaymentOptionComponent implements OnInit {
  orderHistoryClicked: boolean;
  paymentOptionClicked: boolean;
  orderHistoryContent: boolean;
  paymentOptionContent: boolean;
  creditCardInfo: boolean;
  addFirstCard: boolean;

  constructor() {
  }

  ngOnInit(): void {
    this.orderHistoryClicked = true;
    this.paymentOptionClicked = false;
    this.orderHistoryContent = true;
    this.paymentOptionContent = true;
    this.addFirstCard = true;
    this.creditCardInfo = false;
  }

  orderHistoryBtn(): void {
    this.orderHistoryClicked = true;
    this.paymentOptionClicked = false;
    this.orderHistoryContent = true;
    this.paymentOptionContent = false;
  }

  paymentOptionBtn(): void {
    this.orderHistoryClicked = false;
    this.paymentOptionClicked = true;
    this.orderHistoryContent = false;
    this.paymentOptionContent = true;
  }

  addCard(): void {

  }

  editCreditCard(): void {

  }
}
