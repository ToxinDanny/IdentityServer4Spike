import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private client: HttpClient) { }
  CallApi() {
    this.client.get(apiURI + 'Get');
  }
}
