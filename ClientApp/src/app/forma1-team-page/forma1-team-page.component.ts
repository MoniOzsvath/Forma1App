import { Component, OnInit, OnDestroy } from '@angular/core';
import { Forma1TeamService } from '../service/forma1-team.service';
import { TeamReturn } from '../models/team-return';
import { Subscription } from 'rxjs';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { TeamAddOrUpdate } from '../models/team-add-or-update';
import { first } from 'rxjs/operators';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Forma1TeamModalComponent } from '../forma1-team-modal/forma1-team-modal.component';

@Component({
  selector: 'app-forma1-team-page',
  templateUrl: './forma1-team-page.component.html',
  styleUrls: ['./forma1-team-page.component.css']
})
export class Forma1TeamPageComponent implements OnInit, OnDestroy {

  private forma1Teams: TeamReturn[] = [];
  private forma1TeamsSubscription: Subscription;
  private loggedIn = false;
  private loggedInSubsciption: Subscription;

  constructor(
    private forma1TeamService: Forma1TeamService,
    private authorizeService: AuthorizeService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.forma1TeamsSubscription = this.forma1TeamService.getAllForma1Teams()
      .subscribe((x: TeamReturn[]) => this.forma1Teams = x);

    this.loggedInSubsciption = this.authorizeService.isAuthenticated().subscribe((x: boolean) => this.loggedIn = x);

  }

  ngOnDestroy(): void {
    this.forma1TeamsSubscription.unsubscribe();
    this.loggedInSubsciption.unsubscribe();
  }

  onAdd(team: TeamAddOrUpdate): void {
    this.forma1TeamService.addTeam(team).pipe(first()).subscribe((teamReturn: TeamReturn) => {
      this.forma1Teams.push(teamReturn);
    });
  }

  onEdit(team: TeamAddOrUpdate): void {
    this.forma1TeamService.updateTeam(team).pipe(first()).subscribe((teamReturn: TeamReturn) => {
      const index = this.forma1Teams.findIndex(y => y.id = teamReturn.id);
      this.forma1Teams[index] = teamReturn;
    });
  }

  onDelet(id: number): void {
    this.forma1TeamService.deleteTeam(id).pipe(first()).subscribe(() => {
      const index = this.forma1Teams.findIndex(x => x.id = id);
      this.forma1Teams.splice(index, 1);
    });
  }

  onModalOpen(team: TeamReturn | null): void {
    const modalRef = this.modalService.open(Forma1TeamModalComponent, { ariaLabelledBy: 'modal-basic-title' });
    modalRef.result.then((result: TeamAddOrUpdate | null) => {
      if (result === null) {
        return;
      }
      if (team === null) {
        this.onAdd(result);
      } else {
        this.onEdit(result);
      }
    }, () => { });
    modalRef.componentInstance.team = { ...team } || {} as TeamReturn;
  }

}
