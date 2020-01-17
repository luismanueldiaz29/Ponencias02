import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Programa } from '../models/Programa';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ProgramaService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  /** POST: add a new Programa to the server */
  add(Programa: Programa): Observable<Programa> {

    return this.http.post<Programa>(this.baseUrl + 'api/Programa', Programa, httpOptions).pipe(
      tap((newPrograma: Programa) => this.log(`added newPrograma w/ id=${newPrograma.id}`)),
      catchError(this.handleError<Programa>('addPrograma'))
    );
  }

   /** GET heroes from the server */
  getAll(): Observable<Programa[]> {
    return this.http.get<Programa[]>(this.baseUrl + 'api/Programa')
      .pipe(
        tap(_ => this.log('fetched Programa')),
        catchError(this.handleError<Programa[]>('getPrograma', []))
      );
  }

  get(id: number): Observable<Programa> {
    const url = `${this.baseUrl + 'api/Programa'}/${id}`;
    return this.http.get<Programa>(url).pipe(
      tap(_ => this.log(`fetched Programa id=${id}`)),
      catchError(this.handleError<Programa>(`Programa id=${id}`))
    );
  }

  getFacultad(id: number): Observable<Programa> {
    const url = `${this.baseUrl + 'api/Programa/Docente'}/${id}`;
    return this.http.get<Programa>(url).pipe(
      tap(_ => this.log(`fetched Programa id=${id}`)),
      catchError(this.handleError<Programa>(`Programa id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (Programa: Programa): Observable<any> {
    const url = `${this.baseUrl + 'api/Programa'}/${Programa.id}`;
    return this.http.put(url, Programa, httpOptions).pipe(
      tap(_ => this.log(`updated Programa id=${Programa.id}`)),
      catchError(this.handleError<any>('Programa'))
    );
  }

  /** DELETE: delete the hero from the server */
  delete (Programa: Programa | number): Observable<Programa> {
    const id = typeof Programa === 'number' ? Programa : Programa.id;
    const url = `${this.baseUrl + 'api/Programa'}/${id}`;

    return this.http.delete<Programa>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Programa id=${id}`)),
      catchError(this.handleError<Programa>('deletePrograma'))
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
