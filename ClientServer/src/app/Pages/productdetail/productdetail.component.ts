import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';
import { SanPham } from 'src/app/core/Model/sanpham.model';
import { SanphamService } from 'src/app/core/service/sanpham.service';
interface Cart {
  maSp?: string;
  tenSp?: string;
  hinhAnh?: string;
  dongia?: number;
  soluong: number
}
@Component({
  selector: 'app-productdetail',
  templateUrl: './productdetail.component.html',
  styleUrls: ['./productdetail.component.css']
})

export class ProductdetailComponent extends BaseComponent implements OnInit, AfterViewInit {
  public item: any;
  public id: any;
  datasp?: SanPham[] = [];
  dataspLienQuan?: SanPham[] = [];
  constructor(injector: Injector, private route: ActivatedRoute, private spservice: SanphamService) {
    super(injector);
  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      let id = params['id'];
      debugger;
      this._api.get('/api/sanpham/get-by-id/' + id).takeUntil(this.unsubscribe).subscribe(res => {
        this.item = res;
        debugger;
        setTimeout(() => {
          this.loadScripts();
        });
      });
    });
    this.getsp();
    this.getSpLienQuan();

  }
  getSpLienQuan() {
    this.spservice.getsplienquan(this.item.maLoaiSp).subscribe((res: any) => {
      this.dataspLienQuan = res;
    });
  }
  getsp() {
    this.spservice.getallsp().subscribe((res: any) => {
      this.datasp = res;
    })

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
  ngAfterViewInit() {
    this.loadScripts();
  }
}
