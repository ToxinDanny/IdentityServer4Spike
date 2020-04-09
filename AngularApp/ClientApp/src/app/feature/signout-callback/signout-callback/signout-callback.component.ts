import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signout-callback',
  template: `<div></div>`
})
export class SignoutCallbackComponent implements OnInit {

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit() {
    this.authService.completeLogout().then(() => {
      this.router.navigate(['/'], {replaceUrl: true}).then();
    });
  }

}
