import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { TeamAddOrUpdate } from '../models/team-add-or-update';
import { TeamReturn } from '../models/team-return';

@Injectable({
  providedIn: 'root'
})
export class Forma1TeamService {

  private backendUrl = "https://localhost:5001/";
  private forma1TeamPath = "Forma1Team/";
  private forma1TeamsUrl = this.backendUrl + this.forma1TeamPath;
  private headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private httpClient: HttpClient) { }

  getAllForma1Teams(): Observable<TeamReturn[]> {

    return this.httpClient.get<TeamReturn[]>(this.forma1TeamsUrl)
      .pipe(
        catchError(this.errorHandler)
      )
  }


  getById(id: number): Observable<TeamReturn> {
    return this.httpClient.get<TeamReturn>(this.forma1TeamsUrl + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }


  updateTeam(team: TeamAddOrUpdate): Observable<TeamReturn> {
    return this.httpClient.put<TeamReturn>(this.forma1TeamsUrl, team).pipe(
      catchError(this.errorHandler)
    );
  }

  addTeam(team: TeamAddOrUpdate): Observable<TeamReturn> {
    return this.httpClient.post<TeamReturn>(this.forma1TeamsUrl, team, { headers: this.headers }).pipe(
      catchError(this.errorHandler)
    );
  }


  deleteTeam(id: number): Observable<void> {
    return this.httpClient.delete<void>(this.forma1TeamsUrl + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }


  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
