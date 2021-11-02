import { AfterViewInit, Component,Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/core/base-component';
import { SanPham } from 'src/app/core/Model/sanpham.model';
import { SanphamService } from 'src/app/core/service/sanpham.service';

@Component({
  selector: 'app-productdetail',
  templateUrl: './productdetail.component.html',
  styleUrls: ['./productdetail.component.css']
})
export class ProductdetailComponent extends BaseComponent implements OnInit,  AfterViewInit  {
  public item:any;
  public id:any;
  datasp?:SanPham[]=[];
  constructor(injector: Injector, private route: ActivatedRoute,private spservice:SanphamService) { 
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
    
  }
  
  getsp(){
    this.spservice.getallsp().subscribe((res:any)=>{
      this.datasp=res;
    })
    
    }

  ngAfterViewInit() { 
    this.loadScripts(); 
   }
}
