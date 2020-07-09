import { Component, OnInit, ViewChild } from '@angular/core';
import { PropertyModel } from 'src/app/shared/models/property.model';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { ProductPropertyValueModel } from 'src/app/shared/models/productPropertyValue.model';
import { NgForm } from '@angular/forms';
import { ProductPropertyValueComponent } from '../product-property-value/product-property-value.component';
import { CategoryModel } from 'src/app/shared/models/category.model';
import { AdModel } from 'src/app/shared/models/ad.model';
import { AdStatus } from 'src/app/shared/enums/adStatus.enum';
import { ResponseModel } from 'src/app/shared/models/response.model';
import { AdService } from '../ad.service';

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
  id: string;
  editMode = false;

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
    private adService: AdService,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.data.subscribe((response) => {
      this.categories = response.categoryListResolve.data;
    });

    this.route.params
      .subscribe((params: Params) => {
        this.id = params.id;
        this.editMode = params.id != null;
        if (this.editMode) {
          this.getAdById();

        }
      });
  }

  onSubmit() {
    this.ad.product.productPropertyValues = this.productPropertyValues;
    this.ad.product.productPropertyValues.map(ppv => ppv.product = null);
    if (this.mainForm.valid) {
      if (this.editMode) {
        this.adService.editAd(this.authService.nameId, this.id, this.ad).subscribe(res => {
          this.toaster.success('Your ad is updated successfully');
          this.router.navigate(['/ads', this.id]);
        }, error => {
          console.log(error);
          this.toaster.error(error);
        });
      } else {
        this.adService.addAd(this.authService.nameId, this.ad).subscribe(res => {
          this.toaster.success('Your ad is created successfully');
        }, error => {
          console.log(error);
          this.toaster.error(error);
        });
      }

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

  getAdById() {
    this.adService.getAdDetailForEdit(this.authService.nameId, this.id).subscribe((response: ResponseModel) => {
      this.ad = response.data;
      this.setProductPropertyValues();
    });
  }

  setProductPropertyValues() {
    this.productPropertyValues = [];
    const category = this.categories.find(c => c.id === this.ad.categoryId);

    if (this.checkToSetPropertyValues(category)) {
      this.ad.product.productPropertyValues.map((ppv: ProductPropertyValueModel) => {
        const property = category.properties.find(p => p.id === ppv.propertyId);
        if (property) {
          const productPropertyModel: ProductPropertyValueModel = {
            property,
            propertyId: ppv.propertyId,
            product: this.ad.product,
            productId: this.ad.product.id,
            value: ppv.value
          };
          this.productPropertyValues.push(productPropertyModel);
        }
      });
    }
  }

  checkToSetPropertyValues(category: CategoryModel) {
    // tslint:disable-next-line:max-line-length
    return (category.properties && category.properties.length > 0) && (this.ad && this.ad.product && this.ad.product.productPropertyValues && this.ad.product.productPropertyValues.length > 0);
  }

}

