import { Component, Injector, OnInit } from '@angular/core';
import { ApiService } from 'src/app/core/service/api.service';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { Subject } from 'rxjs';
import { BaseComponent } from 'src/app/core/base-component';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent extends BaseComponent implements OnInit {
  public menus:any;
  total:any;
  constructor(injector: Injector) {
    super(injector);
   }

  ngOnInit(): void {
    this._api.get('/api/loaisanpham/get-all1').takeUntil(this.unsubscribe).subscribe(res => {
      this.menus = res;
    }); 
    // this._cart.items.subscribe((res) => {
    //   this.total = res? res.length:0;
    // });
  }

}
