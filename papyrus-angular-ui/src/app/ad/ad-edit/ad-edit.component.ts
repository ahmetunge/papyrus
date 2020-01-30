import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/category/category.service';
import { KeyValueModel } from 'src/app/_models/keyValueModel';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-ad-edit',
  templateUrl: './ad-edit.component.html',
  styleUrls: ['./ad-edit.component.css']
})
export class AdEditComponent implements OnInit {
  categories: KeyValueModel[];

  constructor(
    private categoryService: CategoryService,
    private toaster: ToastrService
  ) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {
    this.categoryService.getCategoriesForAd().subscribe(res => {
      this.categories = res;
    },
      error => this.toaster.error(error));
  }

}
