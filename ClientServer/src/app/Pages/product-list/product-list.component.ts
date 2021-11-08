import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '../../core/base-component';


interface Cart {
  maSp?: string;
  tenSp?: string;
  hinhAnh?: string;
  dongia?: number;
  soluong: number
}
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent extends BaseComponent implements OnInit {

  public list_item: any;
  public page = 1;
  public pageSize = 3;
  public totalItems:any;
  public listCaterogry:any;

  
  constructor(injector: Injector,private route: ActivatedRoute, private router: Router) { 
    super(injector);
    
  }

  ngOnInit(): void {
    window.scroll(0,0);
    this.route.params.subscribe(params => {
      let id = params['id'];
      this._api.post('/api/SanPham/get-all-item-id',{page: this.page, pageSize: this.pageSize, maloai: id}).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_item = res.data;
        this.totalItems = res.total;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
  }

  loadPage(page) { 
    this._route.params.subscribe(params => {
      let id = params['id'];
      this._api.post('/api/SanPham/get-all-item-id', { page: page, pageSize: this.pageSize, maloai: id}).takeUntil(this.unsubscribe).subscribe(res => {
        this.list_item = res.data;
        this.totalItems = res.total;
        }, err => { });       
   });   
  }
  themGioHang(sanpham: any) {
    var Cart = localStorage.getItem("cart");

    if (Cart) {
      var ListCart: Cart[] = JSON.parse(Cart);
      var itemIndex = ListCart.findIndex(item => item.maSp == sanpham.maSp);
      if (itemIndex != -1) {
        ListCart[itemIndex].soluong += 1;
      }
      else {
        var cart: Cart = {
          maSp: sanpham.maSp,
          tenSp: sanpham.tenSp,
          hinhAnh: sanpham.hinhAnh,
          dongia: sanpham.dongia,
          soluong: 1
        };
        ListCart.push(cart);
      }
      window.localStorage.setItem("cart", JSON.stringify(ListCart));

    }
    else {
      var ListCart: Cart[] = [];
      var cart: Cart = {
        maSp: sanpham.maSp,
        tenSp: sanpham.tenSp,
        hinhAnh: sanpham.hinhAnh,
        dongia: sanpham.dongia,
        soluong: 1
      };
      ListCart.push(cart);
      window.localStorage.setItem("cart", JSON.stringify(ListCart));
    }
  }
}
