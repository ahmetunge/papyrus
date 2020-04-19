import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(
    public authService: AuthService,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit() {
    this.model.password = '1907';
    this.model.email = 'ahmetunge@outlook.com';
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.toastr.success('Login successfully');
    }, error => {
      this.toastr.error(error);
    }, () => {
      this.router.navigate(['/home']);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.toastr.success('logged out');
    this.router.navigate(['/home']);
  }

}
