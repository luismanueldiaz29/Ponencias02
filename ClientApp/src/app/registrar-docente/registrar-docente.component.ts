import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../material/material';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Docente } from '../models/docente';
import { ProgramaService } from '../services/Programa.service';
import { FacultadService } from '../services/facultad.service';
import { DocenteService } from '../services/docente.service';
import { Facultad } from '../models/facultad';
import { Programa } from '../models/Programa';
import { GrupoInvestigacionService } from '../services/grupoInvestigacion.service';
import { GrupoInvestigacion } from '../models/grupoInvestingacion';

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
  grupoInvestigaciones : GrupoInvestigacion[];
  programas : Programa[];
  grupoInvestigacionId : number;
  facultadId : number;

  constructor(
    private _formBuilder: FormBuilder,
    private programaService : ProgramaService,
    private grupoService : GrupoInvestigacionService,
    private docenteService : DocenteService
  ) { }

  ngOnInit() {
    this.loadData();
    // this.formGroups();
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
      facultadId : this.facultadId,
      grupoInvestigacionId : this.grupoInvestigacionId
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
    this.grupoService.getAll().subscribe(
      grupo => {
        this.grupoInvestigaciones = grupo
    });

    this.programaService.getAll().subscribe(
      programa => {
        this.programas = programa;
      }
    );
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    // if (this.formGroup.invalid) {
    //   return;
    // }
    alert('id: '+this.docente.id+' nombre : '+this.docente.Nombres+' apelldios '+this.docente.Apellidos+' vinculo '+this.docente.VinculoInst+'facultadid'+this.docente.facultadId+' grupo: '+this.docente.grupoInvestigacionId);
    this.add();
  }

  onReset() {
    this.submitted = false;
    this.formGroup.reset();
  }

  add(){
    this.docenteService.add(this.docente).subscribe(
      docente => {
        docente != null ? 
        alert('se agrego el docente '+docente.Nombres) : alert('ocurrio un error')
      }
    );
  }

}
