import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SolicitudComponent } from './solicitud/solicitud.component';
import { LoginComponent } from './login/login.component';
import { RegistrarDocenteComponent } from './registrar-docente/registrar-docente.component';

const routes : Routes = [
  {
    path : '',
    component : LoginComponent
  },
  {
    path : 'Solicitud',
    component : SolicitudComponent 
  },
  {
    path : 'Home',
    component : HomeComponent
  },
  {
    path : "Registrar",
    component : RegistrarDocenteComponent
  }
]

@NgModule({
  imports : [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
