import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {NgbPaginationModule,NgbAlert } from '@ng-bootstrap/ng-bootstrap'
@NgModule({
  declarations: [
    AppComponent,
     
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbPaginationModule
    ,NgbAlert,

    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
