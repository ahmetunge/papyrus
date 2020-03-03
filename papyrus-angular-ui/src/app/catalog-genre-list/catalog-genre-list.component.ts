import { Component, OnInit } from '@angular/core';

// import { Component, OnInit, Output, EventEmitter, Input, ViewChild } from '@angular/core';
// import { Catalog } from '../_models/catalog';
// import { CatalogCommonService } from '../_services/catalog-common.service';
// import { KeyValueModel } from '../_models/keyValueModel';
// import { NgForm, NgModel } from '@angular/forms';
// import { GenreModel } from '../_models/genre-model';

@Component({
  selector: 'app-catalog-genre-list',
  templateUrl: './catalog-genre-list.component.html',
  styleUrls: ['./catalog-genre-list.component.css']
})
export class CatalogGenreListComponent implements OnInit {
  ngOnInit(): void {
    throw new Error();
  }

  // @Input() selectedGenreId: string;
  // catalogs: Catalog[];
  // genres: KeyValueModel[];
  // @Input() selectedCatalogId: string;
  // @ViewChild('genre', { static: false }) genre: NgModel;
  // genreModel: GenreModel;
  // @Output() getGenreSelect = new EventEmitter<GenreModel>();

  // constructor(
  //   private catalogCommonService: CatalogCommonService
  // ) { }

  // ngOnInit() {
  //   this.getCatalogList();
  // }

  // getCatalogList() {
  //   this.catalogCommonService.getCatalogs().subscribe(res => {
  //     this.catalogs = res;
  //     this.onCatalogChange();
  //   }, err => {
  //     console.log('Error when retrive catalogs');
  //   });
  // }

  // onCatalogChange() {
  //   if (this.selectedCatalogId !== '') {
  //     this.genres = this.catalogs.find(c => c.id === this.selectedCatalogId).genres;
  //     this.onGenreSelect();
  //   }
  // }

  // onGenreSelect() {
  //   this.genreModel = {
  //     selectedGenreId: this.selectedGenreId,
  //     isValid: this.genre.valid
  //   };
  //   this.getGenreSelect.emit(this.genreModel);
  // }

}
