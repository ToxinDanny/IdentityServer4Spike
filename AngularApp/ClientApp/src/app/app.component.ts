import {Component, OnInit} from '@angular/core';
import {AuthService} from './core/service/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  isLogged = false;

  constructor(private authService: AuthService) {
    this.authService.loginChanged.subscribe(loggedIn => {
      this.isLogged = loggedIn;
    });
  }

  ngOnInit() {
    this.authService.isLoggedIn().then(loggedIn => {
      this.isLogged = loggedIn;
    });
  }
}
