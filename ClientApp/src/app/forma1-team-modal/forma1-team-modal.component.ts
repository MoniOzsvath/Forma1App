import { Component, Input, Output } from '@angular/core';
import { TeamReturn } from '../models/team-return';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-forma1-team-modal',
  templateUrl: './forma1-team-modal.component.html',
  styleUrls: ['./forma1-team-modal.component.css']
})
export class Forma1TeamModalComponent {
  @Input() team: TeamReturn = {} as TeamReturn;

  constructor(public activeModal: NgbActiveModal) { }
}
