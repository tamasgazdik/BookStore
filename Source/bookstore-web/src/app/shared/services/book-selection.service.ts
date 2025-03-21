import { Injectable, signal } from '@angular/core';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookSelectionService {
  constructor() { }

  selectedBooks = signal<Book[]>([]);

  addBookToSelectedBooks(book: Book) {
    if (!book) {
      return;
    }
    
    if (!this.selectedBooks().some(bookInArray => bookInArray.id == book.id)) {
      this.selectedBooks.set([ ...this.selectedBooks(), book ]);
    }
  }

  removeBookByTitle(title: string) {
    this.selectedBooks.set(this.selectedBooks().filter(book => {
      return book.title !== title;
    }));
  }
}
