import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  visible: boolean;
  able = true;

  Login() {
    alert('Benvenuto coglione');
    this.visible = true;
    this.able = !this.able;
  }

  CallApi() {
    alert('Bravo coglione');
  }

  Logout() {
    alert('Ciao coglione');
    this.visible = false;
    this.able = !this.able;
  }
}
