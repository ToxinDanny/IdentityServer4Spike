import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {apiUri} from '../../const/uri';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private client: HttpClient) { }

  CallApi() {
    this.client.get(apiUri + 'Get');
  }
}
