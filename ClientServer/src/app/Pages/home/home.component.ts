import { AfterViewInit, Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/core/base-component';
import { LoaisanphamService } from 'src/app/core/service/loaisanpham.service';
import { LoaiSanPham } from 'src/app/core/Model/loaisanpham.model';
import { SanPham } from 'src/app/core/Model/sanpham.model';
import { SanphamService } from 'src/app/core/service/sanpham.service';
import { TinTuc } from 'src/app/core/Model/tintuc.model';
import{ TintucService} from 'src/app/core/service/tintuc.servive';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent extends BaseComponent implements OnInit, AfterViewInit {
  datalsp?:LoaiSanPham[]=[];
  datasp?:SanPham[]=[];
  blogs?:TinTuc[]=[]
  constructor(injector: Injector,private lspservice:LoaisanphamService,private spservice:SanphamService, private blog:TintucService) { 
    super(injector);
  }
  
  ngOnInit(): void {
    this.getlsp();
    this.getsp();
    this.getblog();
  }
  showsp(masp?:string){
    this.datasp=null;
    this.spservice.getspid(masp).subscribe((res:any)=>{
      this.datasp=res;
    })
  }
  getlsp(){
    this.lspservice.getloaisp().subscribe((res:any)=>{
       this.datalsp=res;
    })
  }
getsp(){
this.spservice.getallsp().subscribe((res:any)=>{
  this.datasp=res;
console.log(res)
})

}
getblog(){
  this.blog.gettin().subscribe((res:any)=>{
    this.blogs=res;
  })
}
  ngAfterViewInit() { 
    this.loadScripts(); 
  }

}
