import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Investigacion } from '../models/Investigacion';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class InvestigacionService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  /** POST: add a new Investigacion to the server */
  add(Investigacion: Investigacion): Observable<Investigacion> {

    return this.http.post<Investigacion>(this.baseUrl + 'api/Investigacion', Investigacion, httpOptions).pipe(
      tap((newInvestigacion: Investigacion) => this.log(`added newInvestigacion w/ id=${newInvestigacion.id}`)),
      catchError(this.handleError<Investigacion>('addInvestigacion'))
    );
  }

   /** GET heroes from the server */
  getAll(): Observable<Investigacion[]> {
    return this.http.get<Investigacion[]>(this.baseUrl + 'api/Investigacion')
      .pipe(
        tap(_ => this.log('fetched Investigacion')),
        catchError(this.handleError<Investigacion[]>('getInvestigacion', []))
      );
  }

  get(id: number): Observable<Investigacion> {
    const url = `${this.baseUrl + 'api/Investigacion'}/${id}`;
    return this.http.get<Investigacion>(url).pipe(
      tap(_ => this.log(`fetched Investigacion id=${id}`)),
      catchError(this.handleError<Investigacion>(`Investigacion id=${id}`))
    );
  }

  getInvestigacionSolicitud(id: number): Observable<Investigacion> {
    const url = `${this.baseUrl + 'api/Investigacion/Solicitud'}/${id}`;
    return this.http.get<Investigacion>(url).pipe(
      tap(_ => this.log(`fetched Investigacion id=${id}`)),
      catchError(this.handleError<Investigacion>(`Investigacion id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (Investigacion: Investigacion): Observable<any> {
    const url = `${this.baseUrl + 'api/Investigacion'}/${Investigacion.id}`;
    return this.http.put(url, Investigacion, httpOptions).pipe(
      tap(_ => this.log(`updated Investigacion id=${Investigacion.id}`)),
      catchError(this.handleError<any>('Investigacion'))
    );
  }


  /** DELETE: delete the hero from the server */
  delete (Investigacion: Investigacion | number): Observable<Investigacion> {
    const id = typeof Investigacion === 'number' ? Investigacion : Investigacion.id;
    const url = `${this.baseUrl + 'api/Investigacion'}/${id}`;

    return this.http.delete<Investigacion>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Investigacion id=${id}`)),
      catchError(this.handleError<Investigacion>('deleteInvestigacion'))
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
