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
<<<<<<< HEAD
import { NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
=======
import { DateVNPipe } from '../shared/pipe/DateVN.pipe';


>>>>>>> 4193252c8ffb4313ead6acbf29bc6d99e6c2187a
@NgModule({
  declarations: [HomeComponent, ProductdetailComponent, BlogComponent, CartComponent, ContactComponent, BlogDetailComponent, ProductListComponent, DateVNPipe],
  imports: [
    CommonModule,
    NgbModule,
    NgbPaginationModule,

    RouterModule,
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
    DateVNPipe
  ],
})
export class PagesModule { }
