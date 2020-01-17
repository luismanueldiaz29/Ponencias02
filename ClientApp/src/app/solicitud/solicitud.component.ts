import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../material/material';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-solicitud',
  templateUrl: './solicitud.component.html',
  styleUrls: ['./solicitud.component.css']
})
export class SolicitudComponent implements OnInit {

  imports : [MaterialModule];
  
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  constructor() { }

  showSpinner = false;
  
  loadData(){
    this.showSpinner = true;
    setTimeout(() =>{
      this.showSpinner = false
    }, 1500);
  }


  ngOnInit() {
    this.loadData();
  }

}
