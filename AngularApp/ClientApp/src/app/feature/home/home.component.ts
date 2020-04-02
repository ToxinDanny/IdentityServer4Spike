import { Component } from '@angular/core';
import {AuthService} from '../../core/service/auth.service';
import { User } from 'oidc-client';
import {CallApiService} from '../../core/service/call-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  isLoginEnabled: boolean;
  isLogoutEnabled: boolean;
  isCallApiEnabled: boolean;
  value: any;

  constructor(public authService: AuthService,
              private callApiService: CallApiService) {
    this.authService.isLoggedIn().then(isLoggedIn => {
      this.isLoginEnabled = !isLoggedIn;
      this.isLogoutEnabled = !this.isLoginEnabled;
      this.isCallApiEnabled = isLoggedIn;
    });
  }

  login() {
    this.authService.login().then();
  }

  callApi() {
    this.callApiService.callApi().then(value => {
      this.value = value;
    }, error => {
      this.value = null;
    });
  }

  logout() {
    this.authService.logout().then();
  }
}
