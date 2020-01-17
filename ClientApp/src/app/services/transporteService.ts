import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Transporte } from '../Models/Transporte';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class TransporteService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  /** POST: add a new Transporte to the server */
  add(Transporte: Transporte): Observable<Transporte> {

    return this.http.post<Transporte>(this.baseUrl + 'api/Transporte', Transporte, httpOptions).pipe(
      tap((newTransporte: Transporte) => this.log(`added newTransporte w/ id=${newTransporte.id}`)),
      catchError(this.handleError<Transporte>('addTransporte'))
    );
  }

   /** GET heroes from the server */
  getAll(): Observable<Transporte[]> {
    return this.http.get<Transporte[]>(this.baseUrl + 'api/Transporte')
      .pipe(
        tap(_ => console.log('fetched Transporte')),
        catchError(this.handleError<Transporte[]>('getTransporte', []))
      );
  }

  get(id: number): Observable<Transporte> {
    const url = `${this.baseUrl + 'api/Transporte'}/${id}`;
    return this.http.get<Transporte>(url).pipe(
      tap(_ => this.log(`fetched Transporte id=${id}`)),
      catchError(this.handleError<Transporte>(`Transporte id=${id}`))
    );
  }

  getSolicitudTransporte(id: number): Observable<Transporte> {
    const url = `${this.baseUrl + 'api/Transporte/Solicitud'}/${id}`;
    return this.http.get<Transporte>(url).pipe(
      tap(_ => this.log(`fetched Transporte id=${id}`)),
      catchError(this.handleError<Transporte>(`Transporte id=${id}`))
    );
  }

  /** PUT: update the hero on the server */
  update (Transporte: Transporte): Observable<any> {
    const url = `${this.baseUrl + 'api/Transporte'}/${Transporte.id}`;
    return this.http.put(url, Transporte, httpOptions).pipe(
      tap(_ => this.log(`updated Transporte id=${Transporte.id}`)),
      catchError(this.handleError<any>('Transporte'))
    );
  }


  /** DELETE: delete the hero from the server */
  delete (Transporte: Transporte | number): Observable<Transporte> {
    const id = typeof Transporte === 'number' ? Transporte : Transporte.id;
    const url = `${this.baseUrl + 'api/Transporte'}/${id}`;

    return this.http.delete<Transporte>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Transporte id=${id}`)),
      catchError(this.handleError<Transporte>('deleteTransporte'))
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
