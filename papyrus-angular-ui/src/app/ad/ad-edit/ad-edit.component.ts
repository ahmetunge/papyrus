import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CategoryService } from 'src/app/category/category.service';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_models/category';
import { Ad } from 'src/app/_models/ad';
import { NgForm } from '@angular/forms';
import { AdService } from '../ad.service';
import { Property } from 'src/app/_models/property';


@Component({
  selector: 'app-ad-edit',
  templateUrl: './ad-edit.component.html',
  styleUrls: ['./ad-edit.component.css']
})
export class AdEditComponent implements OnInit {

  @ViewChild('mainForm', { static: false }) mainForm: NgForm;
  categories: Category[];

  selectedProperties: Property[] = [];
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

  onCatagoryChange() {
    if (this.ad.categoryId) {
      const selectedCategory = this.categories.find(c => c.id === this.ad.categoryId);

      if (selectedCategory) {
        this.selectedProperties = selectedCategory.properties;
      }

    }
  }

}
