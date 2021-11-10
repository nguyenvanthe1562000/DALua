import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { ProductdetailComponent } from './productdetail/productdetail.component';
import { BlogComponent } from './blog/blog.component';
import { CartComponent } from './cart/cart.component';
import { ContactComponent } from './contact/contact.component';
import { BlogDetailComponent } from './blog-detail/blog-detail.component';
import { ProductListComponent } from './product-list/product-list.component';

import { NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { DateVNPipe } from '../shared/pipe/DateVN.pipe';
<<<<<<< HEAD

=======
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
<<<<<<< HEAD
<<<<<<< HEAD
=======
import {NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap';
>>>>>>> fca59369011b83080d45bc9031b6231b38cea376

>>>>>>> 2b3d264bbcd7099cf70c5f4a15c82c7467decb1f
=======
import {NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap';

>>>>>>> 2b3d264bbcd7099cf70c5f4a15c82c7467decb1f


@NgModule({
  declarations: [HomeComponent, ProductdetailComponent, BlogComponent, CartComponent, ContactComponent, BlogDetailComponent, ProductListComponent, DateVNPipe],
  imports: [
    NgModule,
    NgbModule,
    NgbPaginationModule,
    CommonModule,
    NgbModule,
    NgbPaginationModule,

    RouterModule,
    NgbModule,
    RouterModule.forChild([
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'product-list/:id',
        component: ProductListComponent
      },
      {
        path: 'product-detail/:id',
        component: ProductdetailComponent
      },
      {
        path: 'blog',
        component: BlogComponent
      },
      {
        path: 'blog-detail/:id',
        component: BlogDetailComponent
      },
      {
        path: 'cart',
        component: CartComponent
      },
      {
        path: 'contact',
        component: ContactComponent
      },
    ])
  ],
  exports: [
    DateVNPipe,
   
  ],
})
export class PagesModule { }
