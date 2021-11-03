import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../core/base-component';

@Component({
  selector: 'app-blog-detail',
  templateUrl: './blog-detail.component.html',
  styleUrls: ['./blog-detail.component.css']
})
export class BlogDetailComponent extends BaseComponent implements OnInit {
 
  public blog:any;
  constructor(injector: Injector,private route: ActivatedRoute) { 
    super(injector);
  }

  ngOnInit(): void {
    window.scroll(0,0);
     this.route.params.subscribe(params => {
      let id = params['id'];
      this._api.get('/api/TinTuc/get-by-id/' + id).takeUntil(this.unsubscribe).subscribe(res => {
        this.blog = res;
      });
    });
  }

}
