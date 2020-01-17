import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route } from '@angular/compiler/src/core';
import { SideNavComponent } from './side-nav/side-nav.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SolicitudComponent } from './solicitud/solicitud.component';
import { LoginComponent } from './login/login.component';

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
    component : SideNavComponent
  }
]

@NgModule({
  imports : [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
