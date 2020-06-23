import { Component, OnInit, ViewChild } from '@angular/core';
import { PropertyModel } from 'src/app/shared/models/property.model';
import { CategoryService } from 'src/app/category/category.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { MemberService } from 'src/app/member/member.service';
import { ProductPropertyValueModel } from 'src/app/shared/models/productPropertyValue.model';
import { NgForm } from '@angular/forms';
import { ProductPropertyValueComponent } from '../product-property-value/product-property-value.component';
import { CategoryModel } from 'src/app/shared/models/category.model';
import { AdModel } from 'src/app/shared/models/ad.model';
import { AdStatus } from 'src/app/shared/enums/adStatus.enum';
import { ResponseModel } from 'src/app/shared/models/response.model';

@Component({
  selector: 'app-ad-edit',
  templateUrl: './ad-edit.component.html',
  styleUrls: ['./ad-edit.component.css']
})
export class AdEditComponent implements OnInit {


  @ViewChild('mainForm', { static: false }) mainForm: NgForm;
  @ViewChild(ProductPropertyValueComponent, { static: false }) productPropertyValueComponent;
  categories: CategoryModel[];
  productPropertyValues: ProductPropertyValueModel[];

  ad: AdModel = {
    status: AdStatus.Active,
    member: null,
    memberId: '',
    category: null,
    categoryId: '',
    id: '',
    title: '',
    description: '',
    product: {
      id: '',
      adId: '',
      productPropertyValues: [],
      ad: null,
      name: ''
    },
    photos: []
  };


  constructor(
    private toaster: ToastrService,
    private route: ActivatedRoute,
    private authService: AuthService,
    private memberService: MemberService
  ) { }



  ngOnInit() {
    this.route.data.subscribe((response) => {
      this.categories = response.categoryListResolve.data;
    });
  }

  onSubmit() {
    this.ad.product.productPropertyValues = this.productPropertyValues;
    this.ad.product.productPropertyValues.map(ppv => ppv.product = null);
    console.log(this.ad);
    if (this.mainForm.valid) {
      this.memberService.addAd(this.authService.nameId, this.ad).subscribe(res => {
        this.toaster.success('Your ad is created successfully');
      }, error => {
        console.log(error);
        this.toaster.error(error);
      });
    } else {
      this.toaster.error('Please enter correct input');
    }
  }

  onCatagoryChange() {
    if (this.ad.categoryId) {
      const selectedCategory = this.categories.find(c => c.id === this.ad.categoryId);

      if (selectedCategory) {
        this.setPropertyValue(selectedCategory.properties);
      }

    }
  }

  setPropertyValue(productPropertyValues: PropertyModel[]) {
    this.productPropertyValues = [];
    productPropertyValues.map((prop: PropertyModel) => {
      const index = this.ad.product.productPropertyValues.findIndex(ppv => ppv.propertyId === prop.id);

      if (index < 0) {
        const productPropertyModel: ProductPropertyValueModel = {
          property: prop,
          propertyId: prop.id,
          product: this.ad.product,
          productId: this.ad.product.id,
          value: ''
        };
        this.productPropertyValues.push(productPropertyModel);
      }
    });
  }

}

