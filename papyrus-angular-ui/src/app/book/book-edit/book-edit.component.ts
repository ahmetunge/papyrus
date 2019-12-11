import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/_models/book';
import { BookService } from '../book.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
  book: Book;

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.book = data.book;
    });
  }

  editBook() {
    this.bookService.editBook(this.book.id, this.book).subscribe((res: any) => {
      debugger;
      this.toastr.success(res.message);
    }, error => {
      debugger;
      this.toastr.error(error.message);
    });
  }

}
