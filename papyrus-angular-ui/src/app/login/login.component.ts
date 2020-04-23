import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

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


}
