import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Facultad } from '../models/facultad';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class FacultadService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }


  /** POST: add a new Facultad to the server */
  add(Facultad: Facultad): Observable<Facultad> {

    return this.http.post<Facultad>(this.baseUrl + 'api/Facultad', Facultad, httpOptions).pipe(
      tap((newFacultad: Facultad) => this.log(`added newFacultad w/ id=${newFacultad.id}`)),
      catchError(this.handleError<Facultad>('addFach,tad'))
    );
  }


   /** GET heroes from the server */
   getAll(): Observable<Facultad[]> {
    return this.http.get<Facultad[]>(this.baseUrl + 'api/Facultad')
      .pipe(
        tap(_ => this.log('fetched Facultad')),
        catchError(this.handleError<Facultad[]>('getFacultad', []))
      );
  }

  get(id: number): Observable<Facultad> {
    const url = `${this.baseUrl + 'api/Facultad'}/${id}`;
    return this.http.get<Facultad>(url).pipe(
      tap(_ => this.log(`fetched Facultad id=${id}`)),
      catchError(this.handleError<Facultad>(`Facultad id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (Facultad: Facultad): Observable<any> {
    const url = `${this.baseUrl + 'api/Facultad'}/${Facultad.id}`;
    return this.http.put(url, Facultad, httpOptions).pipe(
      tap(_ => this.log(`updated Facultad id=${Facultad.id}`)),
      catchError(this.handleError<any>('Facultad'))
    );
  }


  /** DELETE: delete the hero from the server */
  delete (Facultad: Facultad | number): Observable<Facultad> {
    const id = typeof Facultad === 'number' ? Facultad : Facultad.id;
    const url = `${this.baseUrl + 'api/Evento'}/${id}`;

    return this.http.delete<Facultad>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Evento id=${id}`)),
      catchError(this.handleError<Facultad>('deleteEvento'))
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
    // alert(message);
    // this.messageService.add(`HeroService: ${message}`);
  }


}
