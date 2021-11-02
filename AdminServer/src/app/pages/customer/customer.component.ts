import { AfterViewInit, Component, Injector, OnInit, Renderer2 } from '@angular/core';
import { BaseComponent } from '../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent extends BaseComponent implements OnInit {
  public kh: any;
  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    
    this._api.get('/api/khachhang/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.kh = res;
    }); 
    
  }

}
