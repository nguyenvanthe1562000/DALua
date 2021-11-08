import { NgModule } from '@angular/core';
import { RouterModule, Routes  } from '@angular/router';
import { AuthGuard } from './lib/auth.guard';
import { LoginComponent } from './login/login.component';
import { FileNotFoundComponent } from './shared/file-not-found/file-not-found.component';
import { FormsModule } from '@angular/forms';


const routes: Routes = [
  { 
    path: '', loadChildren: () => import('./pages/pages.module').then(m => m.PagesModule),
    // canActivate:[AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '**',
    component: FileNotFoundComponent,
  }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes),FormsModule],
  exports: [RouterModule,FormsModule]
})
export class AppRoutingModule { }
