import { Injectable } from '@angular/core';
import {User, UserManager} from 'oidc-client';
import {Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user: User;
  userManager: UserManager;
  loginChangedSubject = new Subject<boolean>();

  constructor() {
    const stsSetting = {
      authority: authUri,
      client_id: 'angular',
      client_secret: 'secret',
      redirect_uri: clientUri + '/signin-callback',
      scope: 'openid email address profile myApi',
      response: 'code',
      post_logout_redirect_uri: clientUri + '/Home'
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

}
