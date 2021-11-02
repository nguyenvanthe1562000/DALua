import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuleftComponent } from './menuleft/menuleft.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [MenuleftComponent,HeaderComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    MenuleftComponent,HeaderComponent
  ]
})
export class SharedModule { }
