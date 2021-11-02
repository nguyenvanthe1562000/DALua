import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { ProductdetailComponent } from './productdetail/productdetail.component';
import { BlogComponent } from './blog/blog.component';
import { CartComponent } from './cart/cart.component';
import { ContactComponent } from './contact/contact.component';



@NgModule({
  declarations: [HomeComponent, ProductdetailComponent, BlogComponent, CartComponent, ContactComponent],
  imports: [
    CommonModule,
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

        path: 'product-detail/:id',
        component: ProductdetailComponent
      },
      {
        path: 'blog',
        component: BlogComponent
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
})
export class PagesModule { }
