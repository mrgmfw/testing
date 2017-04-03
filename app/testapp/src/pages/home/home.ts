import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';

import { AlertController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {



  constructor(public alertCtrl: AlertController) {
  }
  public formInput:string;
  public formTextarea:string;
  showAlert() {
    var message = this.formInput + this.formTextarea;
    let alert = this.alertCtrl.create({
      title: 'Text Entered',
      subTitle: message,
      buttons: ['OK']
    });
    alert.present();
  }
}
