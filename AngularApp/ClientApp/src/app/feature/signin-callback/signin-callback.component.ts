import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/service/auth.service';
import { Router } from '@angular/router';
import { User } from 'oidc-client';

@Component({
  selector: 'app-signin-callback',
  template: `
    <div>
    </div>
  `
})
export class SigninCallbackComponent implements OnInit {

  constructor(public authService: AuthService,
              private router: Router) { }

  ngOnInit() {
    this.authService.completeLogin().then(() => {
      this.router.navigate(['/'], { replaceUrl: true })
    })
  }

}
