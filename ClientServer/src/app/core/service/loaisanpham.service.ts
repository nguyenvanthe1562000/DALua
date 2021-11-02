import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';
import { LoaiSanPham } from '../Model/loaisanpham.model';
@Injectable({
  providedIn: 'root'
})
export class LoaisanphamService {

  constructor(private _http: HttpClient, public router: Router) { }
  getloaisp(){
    const aipURL='http://localhost:21145/api/loaisanpham/get-all1';
   return this._http.get<LoaiSanPham[]>(aipURL).pipe();
  }
}
