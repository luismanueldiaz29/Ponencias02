import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Solicitud } from '../models/solicitud';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  /** POST: add a new Solicitud to the server */
  add(Solicitud: Solicitud): Observable<Solicitud> {

    return this.http.post<Solicitud>(this.baseUrl + 'api/Solicitud', Solicitud, httpOptions).pipe(
      tap((newSolicitud: Solicitud) => this.log(`added newSolicitud w/ id=${newSolicitud.id}`)),
      catchError(this.handleError<Solicitud>('addSolicitud'))
    );
  }

   /** GET heroes from the server */
  getAll(): Observable<Solicitud[]> {
    return this.http.get<Solicitud[]>(this.baseUrl + 'api/Solicitud')
      .pipe(
        tap(_ => this.log('fetched Solicitud')),
        catchError(this.handleError<Solicitud[]>('getSolicitud', []))
      );
  }

  get(id: number): Observable<Solicitud> {
    const url = `${this.baseUrl + 'api/Solicitud'}/${id}`;
    return this.http.get<Solicitud>(url).pipe(
      tap(_ => this.log(`fetched Solicitud id=${id}`)),
      catchError(this.handleError<Solicitud>(`Solicitud id=${id}`))
    );
  }

  getSolicitudDocente(id : string ): Observable<Solicitud[]>{
    const url = `${this.baseUrl + 'api/Solicitud/Docente'}/${id}`;
    return this.http.get<Solicitud[]>(url)
    .pipe(
      tap(_ => this.log('fetched Solicitud'+_)),
      catchError(this.handleError<Solicitud[]>('getSolicitud', []))
    );
  }

  /** PUT: update the hero on the server */
  update (Solicitud: Solicitud): Observable<any> {
    const url = `${this.baseUrl + 'api/Solicitud'}/${Solicitud.id}`;
    return this.http.put(url, Solicitud, httpOptions).pipe(
      tap(_ => this.log(`updated Solicitud id=${Solicitud.id}`)),
      catchError(this.handleError<any>('Solicitud'))
    );
  }

  /** DELETE: delete the hero from the server */
  delete (Solicitud: Solicitud | number): Observable<Solicitud> {
    const id = typeof Solicitud === 'number' ? Solicitud : Solicitud.id;
    const url = `${this.baseUrl + 'api/Solicitud'}/${id}`;

    return this.http.delete<Solicitud>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Solicitud id=${id}`)),
      catchError(this.handleError<Solicitud>('deleteSolicitud'))
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
