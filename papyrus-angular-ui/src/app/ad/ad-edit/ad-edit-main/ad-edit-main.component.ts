import { Component, OnInit } from '@angular/core';
import { KeyValueModel } from 'src/app/_models/keyValueModel';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from 'src/app/category/category.service';

@Component({
  selector: 'app-ad-edit-main',
  templateUrl: './ad-edit-main.component.html',
  styleUrls: ['./ad-edit-main.component.css']
})
export class AdEditMainComponent implements OnInit {
  categories: KeyValueModel[];

  selectedCategory = '';

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

  onCatagoryChange() {
  }

}
