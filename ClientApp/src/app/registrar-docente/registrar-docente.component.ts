import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../material/material';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Docente } from '../models/docente';
import { ProgramaService } from '../services/Programa.service';
import { FacultadService } from '../services/facultad.service';

@Component({
  selector: 'app-registrar-docente',
  templateUrl: './registrar-docente.component.html',
  styleUrls: ['./registrar-docente.component.css']
})
export class RegistrarDocenteComponent implements OnInit {
  imports : [MaterialModule];
  showSpinner = false;
  docente : Docente;
  submitted : boolean = false;
  private formGroup : FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private programaService : ProgramaService,
    private facultadService : FacultadService
  ) { }

  ngOnInit() {
    this.loadData();
    this.formGroups();
    this.InstanciarDocente();
    this.getAll();
  }

  loadData(){
    this.showSpinner = true;
    setTimeout(() =>{
      this.showSpinner = false
    }, 1500);
  }

  InstanciarDocente(){
    this.docente = {
      id: "",
      Nombres: "",
      Apellidos: "",
      Telefono: "",
      VinculoInst: "",
      Email: "",      
      direccion: "",
      Pass: "",
      facultadId : 0,
      grupoInvestigacionId : 0
    }
  }

  formGroups(){
    this.formGroup = this._formBuilder.group({
      Identificacion: ['', Validators.required],
      Nombres: ['', Validators.required],
      Apellidos: ['', Validators.required],
      VinculoInst: ['', Validators.required],
      Telefono: ['', Validators.required],
      direccion: ['', Validators.required],
      Pass: ['', Validators.required],
      Facultad: ['', Validators.required],
      grupoId: ['', Validators.required],
      //Email : ['', Validators.required]
    });
  }

  getAll(){
    this.facultadService.getAll().subscribe(
      facultad => {
        
      }
    );

    this.programaService.getAll().subscribe(
      programa => {
        
      }
    );
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  onReset() {
    this.submitted = false;
    this.formGroup.reset();
  }

  add(){

  }

}
