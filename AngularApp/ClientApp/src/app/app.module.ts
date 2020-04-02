import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './feature/home/home.component';
import { SigninCallbackComponent } from './feature/signin-callback/signin-callback.component';
import {SigninCallbackModule} from './feature/signin-callback/signin-callback.module';
import {SignoutCallbackComponent} from './feature/signout-callback/signout-callback/signout-callback.component';
import {SignoutCallbackModule} from './feature/signout-callback/signout-callback/signout-callback.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    SigninCallbackModule,
    SignoutCallbackModule,
    RouterModule.forRoot([
      { path: 'signin-callback', component: SigninCallbackComponent, pathMatch: 'full' },
      { path: 'signout-callback', component: SignoutCallbackComponent, pathMatch: 'full' },
      { path: '', component: HomeComponent },
      { path: '**', component: HomeComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
