import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
     
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    HttpClientModule,
<<<<<<< HEAD
 
=======
    FormsModule
>>>>>>> e26c3a43b2ffb9161912abc9f6547da09fe529d7
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
