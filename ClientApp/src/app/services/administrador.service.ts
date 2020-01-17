import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
//import { HandleErrorService } from '../@base/services/handle-error.service';
import { Administrador } from '../models/Administrador';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AdministradorService {

  constructor(
      private http: HttpClient,
      @Inject('BASE_URL') private baseUrl: string,
//      private handlerService : HandleErrorService  
    ) { }

   /** GET heroes from the server */
  getAll(): Observable<Administrador[]> {
    return this.http.get<Administrador[]>(this.baseUrl + 'api/Administrador')
      .pipe(
        tap(_ => console.log('fetched Administrador')),
        catchError(this.handleError<Administrador[]>('getAdministrador', []))
      );
  }

  get(id: string): Observable<Administrador> {
    const url = `${this.baseUrl + 'api/Administrador'}/${id}`;
    return this.http.get<Administrador>(url).pipe(
      tap(_ => this.log(`fetched Administrador id=${id}`)),
      catchError(this.handleError<Administrador>(`Administrador id=${id}`))
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
    //this.handlerService.log(message);
    // this.messageService.add(`HeroService: ${message}`);
  }

}
