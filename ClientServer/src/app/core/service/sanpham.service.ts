import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';
import { SanPham } from '../Model/sanpham.model';
@Injectable({
  providedIn: 'root'
})
export class SanphamService {

  constructor(private _http: HttpClient) { }
  getallsp(){
    const aipURL='http://localhost:21145/api/sanpham/get-all-item';
   return this._http.get<SanPham[]>(aipURL).pipe();
  }
  getspid(masp?:string){
    const aipURL='http://localhost:21145/api/sanpham/get-all-item-id/'+masp;
    return this._http.get<SanPham[]>(aipURL).pipe();
  }
}
