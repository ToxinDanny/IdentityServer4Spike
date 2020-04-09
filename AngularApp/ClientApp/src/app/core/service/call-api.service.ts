import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {apiUri} from '../../const/uri';

@Injectable({
  providedIn: 'root'
})
export class CallApiService {

  constructor(private httpClient: HttpClient) { }

  callApi(): Promise<any> {
    return this.httpClient.get(apiUri).toPromise();
  }
}
