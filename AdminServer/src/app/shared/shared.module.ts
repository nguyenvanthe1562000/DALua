import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuleftComponent } from './menuleft/menuleft.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { FileNotFoundComponent } from './file-not-found/file-not-found.component';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [MenuleftComponent,HeaderComponent, FileNotFoundComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  exports:[
    MenuleftComponent,HeaderComponent
  ]
})
export class SharedModule { }
