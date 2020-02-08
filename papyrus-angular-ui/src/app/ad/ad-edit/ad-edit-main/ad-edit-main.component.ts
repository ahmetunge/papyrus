import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { KeyValueModel } from 'src/app/_models/keyValueModel';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from 'src/app/category/category.service';
import { Category } from 'src/app/_models/category';
import { NgForm } from '@angular/forms';
import { Ad } from 'src/app/_models/ad';
import { AdService } from '../../ad.service';

@Component({
  selector: 'app-ad-edit-main',
  templateUrl: './ad-edit-main.component.html',
  styleUrls: ['./ad-edit-main.component.css']
})
export class AdEditMainComponent implements OnInit {

  @Output() selectCategory = new EventEmitter<Category>();
  @ViewChild('mainForm', { static: false }) mainForm: NgForm;

  categories: KeyValueModel[];
  ad: Ad = {
    id: '',
    categoryId: '',
    title: '',
    description: ''
  };

  constructor(
    private categoryService: CategoryService,
    private toaster: ToastrService,
    private adService: AdService
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

  onSubmit() {
    if (this.mainForm.valid) {
      this.adService.addAd(this.ad).subscribe(res => {
        this.toaster.success('Your ad is created successfully');
      }, error => {
        this.toaster.error(error);
      });
    }
  }

  // onCatagoryChange(event: any) {
  //   if (this.selectedCategoryId) {
  //     const category: Category = {
  //       id: this.selectedCategoryId,
  //       name: this.categories.find(c => c.id === this.selectedCategoryId).name
  //     };

  //     this.selectCategory.emit(category);
  //   }
  // }

}
