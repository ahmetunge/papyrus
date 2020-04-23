import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthService } from './services/auth.service';
import { ErrorInterceptorProvider } from './interceptors/error.interceptor';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './guards/auth.guard';
import { LoginModule } from '../login/login.module';
import { SharedModule } from '../shared/shared.module';



export function getToken() {
  const token = localStorage.getItem('token');
  return token;
}

@NgModule({
  imports: [
    BrowserAnimationsModule,
    RouterModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 2500,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      enableHtml: true
    }),
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    }),

    LoginModule,
    SharedModule
  ],
  declarations: [NavbarComponent],
  exports: [NavbarComponent],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    AuthGuard
  ]
})

export class CoreModule {

}

