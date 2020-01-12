import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Book } from 'src/app/_models/book';
import { BookService } from '../book.service';
import { ToastrService } from 'ngx-toastr';
import { CatalogCommonService } from 'src/app/_services/catalog-common.service';
import { Catalog } from 'src/app/_models/catalog';
import { KeyValueModel } from 'src/app/_models/keyValueModel';
import { error } from 'util';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
  book: Book;
  categoryId: string;
  editMode = false;
  id: string;

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.route.params
      .subscribe((params: Params) => {
        this.id = params.id;
        this.editMode = params.id != null;
        this.initForm();
      });
  }

  initForm() {
    if (this.editMode) {
      this.route.data.subscribe(data => {
        this.book = data.book;
      });
    } else {
      this.book = {
        id: '',
        name: '',
        summary: '',
        genreId: '',
        catalogId: ''
      };
    }
  }

  submitForm() {
    if (this.editMode) {
      this.editBook();
    } else {
      this.addBook();
    }
  }
  addBook() {
    debugger;
    this.bookService.addBook(this.book).subscribe((res: any) => {
      debugger;
      this.toastr.success(res.message);
    }, err => {
      this.toastr.error(err.message);
    });
  }

  editBook() {
    this.bookService.editBook(this.book.id, this.book).subscribe((res: any) => {
      this.toastr.success(res.message);
    }, err => {
      this.toastr.error(err.message);
    });
  }

  selectGenre(event: any) {
    this.book.genreId = event;
  }

}
