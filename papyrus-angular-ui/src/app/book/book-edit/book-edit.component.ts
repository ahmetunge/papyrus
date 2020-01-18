import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Book } from 'src/app/_models/book';
import { BookService } from '../book.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { GenreModel } from 'src/app/_models/genre-model';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
  @ViewChild('bookForm', { static: false }) bookForm: NgForm;
  book: Book;
  categoryId: string;
  editMode = false;
  id: string;
  isGenreValid = false;

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
    if (this.bookForm.valid) {
      if (this.editMode) {
        this.editBook();
      } else {
        this.addBook();
      }
    } else {
      this.toastr.error('Invalid form');
    }

  }
  addBook() {
    this.bookService.addBook(this.book).subscribe((res: any) => {
      this.toastr.success(res.message);
    }, err => {
      this.toastr.error(err.message);
    });
  }

  editBook() {
    this.bookService.editBook(this.id, this.book).subscribe((res: any) => {
      this.toastr.success(res.message);
    }, err => {
      this.toastr.error(err.message);
    });
  }

  selectGenre(genreModel: GenreModel) {
    this.isGenreValid = genreModel.isValid;
    this.book.genreId = genreModel.selectedGenreId;
  }

  isFormValid() {
    return this.isGenreValid && this.bookForm.valid;
  }

}
