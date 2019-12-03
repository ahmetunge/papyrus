import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BookListComponent } from './book/book-list/book-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { BookService } from './book/book.service';
import { JwtModule } from '@auth0/angular-jwt';
import { BookListResolver } from './_resolvers/book-list.resolver';

export function getToken() {
   debugger;
   const token = localStorage.getItem('token');
   return token;
}

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent,
      HomeComponent,
      RegisterComponent,
      BookListComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot({
         timeOut: 2500,
         positionClass: 'toast-top-right',
         preventDuplicates: true,
      }),
      JwtModule.forRoot({
         config: {
            tokenGetter: getToken,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AuthGuard,
      BookService,
      BookListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
