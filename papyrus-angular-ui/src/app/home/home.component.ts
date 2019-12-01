import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(private toastr: ToastrService) { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerMode = true;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

  openToastr() {
    this.toastr.success('Success toastr message');
    this.toastr.warning('Warning toastr message');
    this.toastr.error('Error toastr message');
    this.toastr.info('Info toastr message');
  }

}
