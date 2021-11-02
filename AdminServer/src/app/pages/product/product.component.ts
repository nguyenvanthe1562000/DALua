import { AfterViewInit, Component, Injector, OnInit, Renderer2 } from '@angular/core';
import { BaseComponent } from '../../core/base-component';
import 'rxjs/add/observable/combineLatest';
import 'rxjs/add/operator/takeUntil';
import { ActivatedRoute } from '@angular/router';
import { product } from 'src/app/Model/product.models';
import { ApiService } from 'src/app/service/api.service';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent extends BaseComponent implements OnInit {
  public products: any;
  public page = 1;
  public pageSize = 10;
  public total:any;
  file: any = null;
  pr?:product[];
  proedit?:product;
  constructor(injector: Injector,private route: ActivatedRoute,private api:ApiService) {
    super(injector);
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this._api.post('/api/sanpham/get-all-paginate',{page: this.page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.products = res.data;
        this.total = res.total;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
  }
  del(id?:number){
    if(confirm("xóa ?")==true){
        this._api.post('/api/sanpham/delete-item/'+id,'').toPromise();
        alert("thành công");
        this.ngOnInit();
    }
  }
  showupdate(id?:number){
    this.api.get('/api/sanpham/get-by-id/'+id).subscribe(res => {
      this.proedit=res;
      this.file=res.hinhAnh;
    });
  }
  Onchange(event:any){
    this.file = event.target.files[0];
  }
  add(ten?:string,mota?:string,sl?:any,dongia?:any,msp?:string,donvi?:string)
  {
    const pro:product=new product();
    pro.tenSp=ten;
    pro.maSp=msp;
    pro.moTa=mota;
    pro.hinhAnh=this.file.name;
    pro.soLuongTon=sl;
    pro.dongia=dongia;
    pro.donVi=donvi;
      this.api.addsp(pro).subscribe(res=>{
      this.pr?.push(res);
      alert("Thêm Thành Công");
      this.ngOnInit();
      });
  }
  update(ten?:string,mota?:string,sl?:any,dongia?:any,msp?:string,donvi?:string)
  {
    
    if(this.file.name==null){
      const pro:product=new product();
    pro.tenSp=ten;
    pro.maSp=msp;
    pro.moTa=mota;
    pro.hinhAnh=this.file;
    pro.soLuongTon=sl;
    pro.dongia=dongia;
    pro.donVi=donvi;
    this.api.update(pro).subscribe(res=>{
      this.pr?.push(res);
      alert("Sửa Thành Công");
      this.ngOnInit();
      });
    }
    else{
      const pro:product=new product();
    pro.tenSp=ten;
    pro.maSp=msp;
    pro.moTa=mota;
    pro.hinhAnh=this.file.name;
    pro.soLuongTon=sl;
    pro.dongia=dongia;
    pro.donVi=donvi;
     this.api.update(pro).subscribe(res=>{
      this.pr?.push(res);
      alert("Sửa Thành Công");
      this.ngOnInit();
      });
    }
  }
  loadPage(page:any) { 
    this._route.params.subscribe(params => {
      this._api.post('/api/sanpham/get-all-paginate', { page: page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
        this.products = res.data;
        this.total = res.total;
        }, err => { });       
   });   
  }
}

