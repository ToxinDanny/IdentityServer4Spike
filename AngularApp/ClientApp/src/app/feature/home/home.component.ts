import { Component } from '@angular/core';
import {AuthService} from '../../core/service/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  visible: boolean;
  able = true;

  constructor(private authService: AuthService) {
  }

  Login() {
    this.authService.login();
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
