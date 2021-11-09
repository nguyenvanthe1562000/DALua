import { AfterViewInit, Component, Injector, OnInit, Renderer2 } from '@angular/core';
import { BaseComponent } from '../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';


@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css']
})
export class BillComponent extends BaseComponent implements OnInit {
  public doneSetup = false;
  public orderdetail:any;
  public bills: any;
  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    this._api.get('/api/DonDatHang/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.bills= res;
    }); 
  }
  onRowExpand(row:any) {
    this.doneSetup = false; 
    this._api.get('/api/DonDatHang/get-by-id/'+ row.data.maDonHang).subscribe((res:any) => {
      this.orderdetail = res;
      debugger;
      this.doneSetup = true; 
    });
  }
}
