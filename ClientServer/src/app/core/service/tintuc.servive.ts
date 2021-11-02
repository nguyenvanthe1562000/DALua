import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';
import { TinTuc } from '../Model/tintuc.model';
@Injectable({
  providedIn: 'root'
})
export class TintucService {

  constructor(private _http: HttpClient, public router: Router) { }
  gettin(){
    const aipURL='http://localhost:21145/api/tintuc/get-all';
   return this._http.get<TinTuc[]>(aipURL).pipe();
  }
}
