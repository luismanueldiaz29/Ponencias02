import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Evento } from '../models/evento';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  /** POST: add a new Evento to the server */
  add(Evento: Evento): Observable<Evento> {
    return this.http.post<Evento>(this.baseUrl + 'api/Evento', Evento, httpOptions).pipe(
      tap((newEvento: Evento) => this.log(`added newEvento w/ id=${newEvento.id}`)),
      catchError(this.handleError<Evento>('addEvento'))
    );
  }

   /** GET heroes from the server */
  getAll(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseUrl + 'api/Evento')
      .pipe(
        tap(_ => this.log('fetched Evento')),
        catchError(this.handleError<Evento[]>('getEvento', []))
      );
  }

  get(id: number): Observable<Evento> {
    const url = `${this.baseUrl + 'api/Evento'}/${id}`;
    return this.http.get<Evento>(url).pipe(
      tap(_ => this.log(`fetched Evento id=${id}`)),
      catchError(this.handleError<Evento>(`Evento id=${id}`))
    );
  }

  getEventoSolicitud(id: number): Observable<Evento> {
    const url = `${this.baseUrl + 'api/Evento/Solicitud'}/${id}`;
    return this.http.get<Evento>(url).pipe(
      tap(_ => this.log(`fetched Evento id=${id}`)),
      catchError(this.handleError<Evento>(`Evento id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (Evento: Evento): Observable<any> {
    const url = `${this.baseUrl + 'api/Evento'}/${Evento.id}`;
    return this.http.put(url, Evento, httpOptions).pipe(
      tap(_ => this.log(`updated Evento id=${Evento.id}`)),
      catchError(this.handleError<any>('Evento'))
    );
  }


  /** DELETE: delete the hero from the server */
  delete (Evento: Evento | number): Observable<Evento> {
    const id = typeof Evento === 'number' ? Evento : Evento.id;
    const url = `${this.baseUrl + 'api/Evento'}/${id}`;

    return this.http.delete<Evento>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Evento id=${id}`)),
      catchError(this.handleError<Evento>('deleteEvento'))
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
