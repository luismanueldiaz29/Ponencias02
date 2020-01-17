import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Semillero } from '../models/Semillero';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class SemilleroService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  /** POST: add a new Semillero to the server */
  add(Semillero: Semillero): Observable<Semillero> {
    return this.http.post<Semillero>(this.baseUrl + 'api/Semillero', Semillero, httpOptions).pipe(
      tap((newSemillero: Semillero) => this.log(`added newSemillero w/ id=${newSemillero.id}`)),
      catchError(this.handleError<Semillero>('addSemillero'))
    );
  }

   /** GET heroes from the server */
  getAll(): Observable<Semillero[]> {
    return this.http.get<Semillero[]>(this.baseUrl + 'api/Semillero')
      .pipe(
        tap(_ => this.log('fetched Semillero')),
        catchError(this.handleError<Semillero[]>('getSemillero', []))
      );
  }

  getSemilleroGrupo(id : number ){
    const url = `${this.baseUrl + 'api/Semillero/GrupoInvestigacion'}/${id}`;
    return this.http.get<Semillero>(url).pipe(
      tap(_ => this.log(`fetched Semillero id=${id}`)),
      catchError(this.handleError<Semillero>(`Semillero id=${id}`))
    );
  }

  get(id: number): Observable<Semillero> {
    const url = `${this.baseUrl + 'api/Semillero'}/${id}`;
    return this.http.get<Semillero>(url).pipe(
      tap(_ => this.log(`fetched Semillero id=${id}`)),
      catchError(this.handleError<Semillero>(`Semillero id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (Semillero: Semillero): Observable<any> {
    const url = `${this.baseUrl + 'api/Semillero'}/${Semillero.id}`;
    return this.http.put(url, Semillero, httpOptions).pipe(
      tap(_ => this.log(`updated Semillero id=${Semillero.id}`)),
      catchError(this.handleError<any>('Semillero'))
    );
  }


  /** DELETE: delete the hero from the server */
  delete (Semillero: Semillero | number): Observable<Semillero> {
    const id = typeof Semillero === 'number' ? Semillero : Semillero.id;
    const url = `${this.baseUrl + 'api/Semillero'}/${id}`;

    return this.http.delete<Semillero>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Semillero id=${id}`)),
      catchError(this.handleError<Semillero>('deleteSemillero'))
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
