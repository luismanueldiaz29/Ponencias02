import { Component } from '@angular/core';
import { MaterialModule } from './material/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  // imports : [MaterialModule]
  title = 'app';
  // showSpinner = false;

  // loadData(){
  //   this.showSpinner = true;
  //   setTimeout(() =>{
  //     this.showSpinner = false
  //   }, 5000);
  // }
}
