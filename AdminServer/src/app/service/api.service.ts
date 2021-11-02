import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError } from 'rxjs';
import { product } from 'src/app/Model/product.models';
@Injectable({
  providedIn: 'root',
})
export class ApiService {
  public host = 'http://localhost:21145';
  constructor(private _http: HttpClient, public router: Router) {}
  post(url: string, obj: any) {
    const body = JSON.stringify(obj);
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .post<any>(this.host + url, body, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res ;
        })
      ).pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }
  addsp(sp:product){
    let cloneHeader: any = {};
    const headerOptions = new HttpHeaders(cloneHeader);
    const apiURL='http://localhost:21145/api/sanpham/create-item';
    return this._http.post<product>(apiURL,sp,{ headers: headerOptions }).pipe();
  }
  update(sp:product){
    let cloneHeader: any = {};
    const headerOptions = new HttpHeaders(cloneHeader);
    const apiURL='http://localhost:21145/api/sanpham/update-item';
    return this._http.post<product>(apiURL,sp,{ headers: headerOptions }).pipe();
  }
  getspedit(id?:number){
    const apiURL='http://localhost:21145/api/sanpham/get-by-id/'+id;
    return this._http.get<product>(apiURL).pipe();
  }
  get(url: string) {
    let cloneHeader: any = {};
    cloneHeader['Content-Type'] = 'application/json';
    const headerOptions = new HttpHeaders(cloneHeader);
    return this._http
      .get(this.host + url, { headers: headerOptions })
      .pipe(
        map((res: any) => {
          return res;
        })
      ).pipe(
        catchError((err: Response) => {
          return this.handleError(err);
        })
      );
  }
  public handleError(error: any) {
    // this.router.navigate(['/err']);
    return observableThrowError(error);
  }
}
