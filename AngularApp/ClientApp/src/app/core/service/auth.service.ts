import { Injectable } from '@angular/core';
import {User, UserManager} from 'oidc-client';
import {Subject} from 'rxjs';
import {authUri, clientUri} from '../../const/uri';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user: User;
  userManager: UserManager;
  loginChangedSubject = new Subject<boolean>();

  loginChanged = this.loginChangedSubject.asObservable();

  constructor() {
    const stsSetting = {
      authority: authUri,
      client_id: 'angular',
      client_secret: 'secret',
      redirect_uri: `${clientUri}/signin-callback`,
      scope: 'openid profile email address myApi',
      response_type: 'code',
      post_logout_redirect_uri: `${clientUri}/signout-callback`
    };
    this.userManager = new UserManager(stsSetting);
  }

  login() {
    return this.userManager.signinRedirect();
  }

  isLoggedIn(): Promise<boolean> {
    return this.userManager.getUser().then( user => {
      const userCurrent = !!user && !user.expired;
      if (this.user !== user) {
        this.loginChangedSubject.next(userCurrent);
      }
      this.user = user;
      return userCurrent;
    });
  }

  completeLogin() {
    return this.userManager.signinRedirectCallback().then(user => {
      this.user = user;
      this.loginChangedSubject.next(!!user && !user.expired);
      return user;
    });
  }

  logout() {
    return this.userManager.signoutRedirect();
  }

  completeLogout() {
    return this.userManager.signoutRedirectCallback().then(response => {
      return response;
    });
  }

  getAccessToken() {
    return this.userManager.getUser().then(user => {
      if(!!user && !user.expired) {
        return user.access_token;
      }
      return null;
    });
  }
}
