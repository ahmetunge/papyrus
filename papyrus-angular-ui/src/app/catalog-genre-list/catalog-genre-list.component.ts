import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Catalog } from '../_models/catalog';
import { CatalogCommonService } from '../_services/catalog-common.service';
import { KeyValueModel } from '../_models/keyValueModel';

@Component({
  selector: 'app-catalog-genre-list',
  templateUrl: './catalog-genre-list.component.html',
  styleUrls: ['./catalog-genre-list.component.css']
})
export class CatalogGenreListComponent implements OnInit {

  selectedGenreId: string;
  catalogs: Catalog[];
  genres: KeyValueModel[];
  selectedCatalogId: string;

  @Output() getGenreSelect = new EventEmitter<string>();
  constructor(
    private catalogCommonService: CatalogCommonService
  ) { }

  ngOnInit() {
    this.getCatalogList();
  }

  getCatalogList() {
    this.catalogCommonService.getCatalogs().subscribe(res => {
      this.catalogs = res;
    }, err => {
      console.log('Error when retrive catalogs');
    });
  }

  onCatalogChange() {
    this.genres = this.catalogs.find(c => c.id === this.selectedCatalogId).genres;
    this.selectedGenreId = '';
  }

  onGenreSelect() {
    this.getGenreSelect.emit(this.selectedGenreId);
  }

}
