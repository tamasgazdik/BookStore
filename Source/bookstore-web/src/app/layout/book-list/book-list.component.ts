import { Component, inject, OnInit, output, signal } from '@angular/core';
import { Book } from '../../shared/models/book';
import { BookToStringPipe } from '../shared/pipes/book-to-string.pipe';
import { BookHttpService } from '../../features/bookstore/services/book-http-service.service';
import { CommonModule } from '@angular/common';
import { BookSelectionService } from '../../shared/services/book-selection.service';

@Component({
  selector: 'app-book-list',
  imports: [BookToStringPipe, CommonModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.scss'
})
export class BookListComponent implements OnInit {
  ngOnInit(): void {
    this.bookHttpService.getBooks()
      .subscribe((bookArray) => {
        if (bookArray.length) {
          this.books.set(bookArray);
        }
      })
  }

  bookHttpService = inject(BookHttpService);
  bookSelectionService = inject(BookSelectionService);
  books = signal<Book[]>([]);
  bookSelected = output();
  newBookSelected = output();

  onBookSelected(book: Book) {
    this.bookSelectionService.addBookToSelectedBooks(book);
    this.bookSelected.emit();
  }

  onNewBookSelected() {
    this.newBookSelected.emit();
  }
}
