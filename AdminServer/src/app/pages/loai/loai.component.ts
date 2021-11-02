import { AfterViewInit, Component, Injector, OnInit, Renderer2 } from '@angular/core';
import { BaseComponent } from '../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';

@Component({
  selector: 'app-loai',
  templateUrl: './loai.component.html',
  styleUrls: ['./loai.component.css']
})
export class LoaiComponent extends BaseComponent implements OnInit {
  public loais: any;
  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    
    this._api.get('/api/loaisanpham/get-all1').takeUntil(this.unsubscribe).subscribe(res => {
      this.loais = res;
    }); 
    
  }
  

}
