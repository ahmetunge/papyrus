import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CategoryService } from 'src/app/category/category.service';
import { KeyValueModel } from 'src/app/_models/keyValueModel';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-ad-edit',
  templateUrl: './ad-edit.component.html',
  styleUrls: ['./ad-edit.component.css']
})
export class AdEditComponent implements OnInit {


  constructor() { }

  ngOnInit() {
  }
}
