import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/_models/book';
import { BookService } from '../book.service';
import { ToastrService } from 'ngx-toastr';
import { Route } from '@angular/compiler/src/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[];

  constructor(private bookService: BookService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit() {
    // this.loadBooks();
  }

  loadBooks() {
    // this.bookService.getBooks().subscribe((books: Book[]) => {
    //   this.books = books;
    // }, error => {
    //   this.toastr.error(error.error);
    // });
    this.route.data.subscribe(data => {
      this.books = data.books;
    });
  }

}
