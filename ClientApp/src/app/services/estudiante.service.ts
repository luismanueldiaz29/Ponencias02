import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Estudiante } from '../models/estudiante';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  /** POST: add a new Estudiante to the server */
  add(Estudiante: Estudiante): Observable<Estudiante> {

    return this.http.post<Estudiante>(this.baseUrl + 'api/Estudiante', Estudiante, httpOptions).pipe(
      tap((newEstudiante: Estudiante) => this.log(`added newEstudiante w/ id=${newEstudiante.id}`)),
      catchError(this.handleError<Estudiante>('addEstudiante'))
    );
  }

   /** GET heroes from the server */
  getAll(): Observable<Estudiante[]> {
    return this.http.get<Estudiante[]>(this.baseUrl + 'api/Estudiante')
      .pipe(
        tap(_ => this.log('fetched Estudiante')),
        catchError(this.handleError<Estudiante[]>('getEstudiante', []))
      );
  }

  get(id: number): Observable<Estudiante> {
    const url = `${this.baseUrl + 'api/Estudiante'}/${id}`;
    return this.http.get<Estudiante>(url).pipe(
      tap(_ => this.log(`fetched Estudiante id=${id}`)),
      catchError(this.handleError<Estudiante>(`Estudiante id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (Estudiante: Estudiante): Observable<any> {
    const url = `${this.baseUrl + 'api/Estudiante'}/${Estudiante.id}`;
    return this.http.put(url, Estudiante, httpOptions).pipe(
      tap(_ => this.log(`updated Estudiante id=${Estudiante.id}`)),
      catchError(this.handleError<any>('Estudiante'))
    );
  }

  /** DELETE: delete the hero from the server */
  delete (Estudiante: Estudiante | number): Observable<Estudiante> {
    const id = typeof Estudiante === 'number' ? Estudiante : Estudiante.id;
    const url = `${this.baseUrl + 'api/Estudiante'}/${id}`;

    return this.http.delete<Estudiante>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Estudiante id=${id}`)),
      catchError(this.handleError<Estudiante>('deleteEstudiante'))
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
