import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SideNavComponent } from './side-nav/side-nav.component';
import { MaterialModule } from './material/material';
import { AppRoutingModule } from './app-routing.module';
import { SolicitudComponent } from './solicitud/solicitud.component';
import { NgProgressModule } from 'ngx-progressbar';
import { LoginComponent } from './login/login.component';
import { RegistrarDocenteComponent } from './registrar-docente/registrar-docente.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SideNavComponent,
    SolicitudComponent,
    LoginComponent,
    RegistrarDocenteComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap : [AppComponent]
})
export class AppModule { }
