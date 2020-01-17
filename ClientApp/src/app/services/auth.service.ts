import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { DocenteService } from './docente.service';
import { Docente } from '../Models/docente';
//import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
//import { AlertModalComponent } from '../@base/modals/alert-modal/alert-modal.component';
import { AdministradorService } from './administrador.service';
import { Administrador } from '../models/Administrador';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    docente : Docente;
    administrador : Administrador;
    constructor(
        private _router: Router,
        //private modalService: NgbModal,
        private docenteService : DocenteService,
        private authService : AuthService,
        private AdministradorService : AdministradorService
    ) {
        
    }
 

    login(user: string, password: string) {
        //validar en el servidor si el usuario y password son válidos.
        //en el caso que sean válidos se deberian retornar los roles que tiene asociado dicho usuario
        //se podría encriptar el nombre de la variable
        
        if(user == "docente"){
            this.docenteService.get(password).subscribe(
                docente => this.AsignarRoles(user, docente.id) 
            );
        }
        if(user == "admin"){
            this.AdministradorService.get(password).subscribe(
                administrador => this.AsignarRoles(user, administrador.id)
            );
        }
    }

    AsignarRoles(user : string, password : string){
        if(password != ""){
            sessionStorage.setItem('user', user);
            sessionStorage.setItem('id', password);
            this._router.navigate(['/Home']);
        }else{
            this.mensaje("mensaje de sugerencia", "No se puede acceder");
        }
    }
    logout() {
      sessionStorage.clear();
      this._router.navigate(['']);
    }

    GuardarSolicitud(id : number){
        sessionStorage.setItem('solicitudId', id.toString());
    }

    getSolicitudId(): string {
        return sessionStorage.getItem('solicitudId') != null ? sessionStorage.getItem('solicitudId'):'Anonimo';
    }

    isAuthenticated(): boolean {
        return sessionStorage.getItem('user')!=null;
    }

    hasRole(rol: string): boolean {
        // if (!this.isAuthenticated()) return false;
        return rol == sessionStorage.getItem('user');
    }

    getUserName(): string {
        return sessionStorage.getItem('id') != null ? sessionStorage.getItem('id'):'Anonimo';
    }


    DocenteSeleccionado(id : string){
        sessionStorage.setItem('DocenteSeleccionado', id);
    }

    getDocenteSeleccionado(): string {
        return sessionStorage.getItem('DocenteSeleccionado') != null ? sessionStorage.getItem('DocenteSeleccionado'):'Anonimo';
    }

    SolicitudRegistarform(id : number){
        sessionStorage.setItem('SolicitudRegistarform', id.toString());
    }
    getSolicitudRegistarform(){
        return sessionStorage.getItem('SolicitudRegistarform') != null ? sessionStorage.getItem('SolicitudRegistarform'):'Anonimo';
    }

    mensaje(titulo : string, mensaje : string){
        // const messageBox = this.modalService.open(AlertModalComponent)
        //   messageBox.componentInstance.title = titulo;
        //   messageBox.componentInstance.message = mensaje; 
    }
}
