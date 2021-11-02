import { AfterViewInit, Component, Injector, OnInit, Renderer2 } from '@angular/core';
import { BaseComponent } from '../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';


@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent extends BaseComponent implements OnInit{

  public blogs: any;
  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    
    this._api.get('/api/tintuc/get-all1').takeUntil(this.unsubscribe).subscribe(res => {
      this.blogs= res;
    }); 
    
  }

}
