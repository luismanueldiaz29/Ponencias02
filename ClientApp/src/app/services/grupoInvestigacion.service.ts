import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { GrupoInvestigacion } from '../models/grupoInvestingacion';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class GrupoInvestigacionService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }


  /** POST: add a new GrupoInvestigacion to the server */
  add(GrupoInvestigacion: GrupoInvestigacion): Observable<GrupoInvestigacion> {

    return this.http.post<GrupoInvestigacion>(this.baseUrl + 'api/GrupoInvestigacion', GrupoInvestigacion, httpOptions).pipe(
      tap((newGrupoInvestigacion: GrupoInvestigacion) => this.log(`added newGrupoInvestigacion w/ id=${newGrupoInvestigacion.id}`)),
      catchError(this.handleError<GrupoInvestigacion>('addFach,tad'))
    );
  }


   /** GET heroes from the server */
   getAll(): Observable<GrupoInvestigacion[]> {
    return this.http.get<GrupoInvestigacion[]>(this.baseUrl + 'api/GrupoInvestigacion')
      .pipe(
        tap(_ => this.log('fetched GrupoInvestigacion')),
        catchError(this.handleError<GrupoInvestigacion[]>('getGrupoInvestigacion', []))
      );
  }

  get(id: number): Observable<GrupoInvestigacion> {
    const url = `${this.baseUrl + 'api/GrupoInvestigacion'}/${id}`;
    return this.http.get<GrupoInvestigacion>(url).pipe(
      tap(_ => this.log(`fetched GrupoInvestigacion id=${id}`)),
      catchError(this.handleError<GrupoInvestigacion>(`GrupoInvestigacion id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (GrupoInvestigacion: GrupoInvestigacion): Observable<any> {
    const url = `${this.baseUrl + 'api/GrupoInvestigacion'}/${GrupoInvestigacion.id}`;
    return this.http.put(url, GrupoInvestigacion, httpOptions).pipe(
      tap(_ => this.log(`updated GrupoInvestigacion id=${GrupoInvestigacion.id}`)),
      catchError(this.handleError<any>('GrupoInvestigacion'))
    );
  }


  /** DELETE: delete the hero from the server */
  delete (GrupoInvestigacion: GrupoInvestigacion | number): Observable<GrupoInvestigacion> {
    const id = typeof GrupoInvestigacion === 'number' ? GrupoInvestigacion : GrupoInvestigacion.id;
    const url = `${this.baseUrl + 'api/GrupoInvestigacion'}/${id}`;

    return this.http.delete<GrupoInvestigacion>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted GrupoInvestigacion id=${id}`)),
      catchError(this.handleError<GrupoInvestigacion>('deleteGrupoInvestigacion'))
    );
  }




  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    console.log(message);
    // this.messageService.add(`HeroService: ${message}`);
  }


}
