import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/_models/book';
import { BookService } from '../book.service';
import { ToastrService } from 'ngx-toastr';
import { CatalogCommonService } from 'src/app/_services/catalog-common.service';
import { Catalog } from 'src/app/_models/catalog';
import { KeyValueModel } from 'src/app/_models/keyValueModel';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
  book: Book;
  categoryId: string;
  catalogs: Catalog[];
  selectedCatalog: string;
  genres: KeyValueModel[];

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService,
    private toastr: ToastrService,
    private catalogService: CatalogCommonService
  ) { }

  ngOnInit() {

    this.route.data.subscribe(data => {
      this.book = data.book;
    });
    this.getCatalogs();
  }

  editBook() {
    this.bookService.editBook(this.book.id, this.book).subscribe((res: any) => {
      this.toastr.success(res.message);
    }, error => {
      this.toastr.error(error.message);
    });
  }

  getCatalogs() {
    this.catalogService.getCatalogs().subscribe(res => {
      this.catalogs = res;
      console.log(res);
    }, err => {
      this.toastr.error(err);
    });
  }

  onCatalogChange(event: string) {
    const genres = this.catalogs.find(c => c.id === this.selectedCatalog).genres;
    this.genres = genres;
  }

}
