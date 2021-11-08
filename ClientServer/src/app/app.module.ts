import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
<<<<<<< HEAD


=======
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap';
>>>>>>> 4193252c8ffb4313ead6acbf29bc6d99e6c2187a

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
<<<<<<< HEAD
   
=======
    NgbPaginationModule,
    NgbModule,
>>>>>>> 4193252c8ffb4313ead6acbf29bc6d99e6c2187a
  ],
 
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


