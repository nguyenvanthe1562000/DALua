import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';
import { RouterModule } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { CustomerComponent } from './customer/customer.component';
import { VendorComponent } from './vendor/vendor.component';
import { BillComponent } from './bill/bill.component';
import { LoaiComponent } from './loai/loai.component';
import { BlogComponent } from './blog/blog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule, NgbPagination } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [MainComponent, ProductComponent, CustomerComponent, VendorComponent, BillComponent, LoaiComponent, BlogComponent],
  imports: [
    ReactiveFormsModule,
    NgbModule,
    // NgbPagination,
    FormsModule,
    CommonModule,
    RouterModule,
    RouterModule.forChild([
      {
        path: '',
        component: MainComponent
      },
      {
        path: 'loai',
        component: LoaiComponent
      },
      {
        path: 'product',
        component: ProductComponent
      },
      {
        path: 'customer',
        component: CustomerComponent
      },
      {
        path: 'Vendor',
        component: VendorComponent
      },
      {
        path: 'bill',
        component: BillComponent
      },
      {
        path: 'blog',
        component: BlogComponent
      },
  ])
], 

})
export class PagesModule { }
