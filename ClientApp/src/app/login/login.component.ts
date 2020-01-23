import { Component, OnInit } from '@angular/core';
import { Routes, Router } from '@angular/router';
import { MaterialModule } from '../material/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  
  imports : [MaterialModule];

  constructor(
    private _router : Router
  ) { }

  ngOnInit() {
  }

  showSpinner = false;
  
  loadData(){
    this.showSpinner = true;
    setTimeout(() =>{
      this.showSpinner = false
    }, 1500);
  }

  acceder(){
    this._router.navigate(['/Home']);
  }

}
