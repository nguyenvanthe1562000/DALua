import { AfterViewInit, Component, Injector, OnInit, Renderer2 } from '@angular/core';
import { BaseComponent } from '../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';


@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent extends BaseComponent implements OnInit {

  public NCC: any;
  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    
    this._api.get('/api/nhacungcap/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.NCC = res;
    }); 
    
  }

}
