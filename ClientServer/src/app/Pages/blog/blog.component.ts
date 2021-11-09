import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent extends BaseComponent implements OnInit {
  public blogs: any;
  public page = 1;
  public pageSize = 10;
  public totalItems:any;
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInit(): void {
    this.search();
  }
  loadPage(page) { 
    this._api.post('/api/TinTuc/get-all-paginate',{page: page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
      this.blogs = res.data;
      this.totalItems =  res.total;
      this.pageSize = res.pageSize;
    });
  } 
  
  search() { 
    this.page = 1;
    this.pageSize = 5;
    this._api.post('/api/TinTuc/get-all-paginate',{page: this.page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
      this.blogs = res.data;
      this.totalItems =  res.totalItems;
      this.pageSize = res.pageSize;
    });
  }
}
