import { Component, inject, input, output, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectedBooksTagsComponent } from "../../features/bookstore/selected-books-tags/selected-books-tags.component";
import { BookSelectionService } from '../../shared/services/book-selection.service';

@Component({
  selector: 'app-book-details',
  imports: [CommonModule, SelectedBooksTagsComponent],
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.scss'
})
export class BookDetailsComponent {
  bookSelectionService = inject(BookSelectionService);
  selectedBooks = this.bookSelectionService.selectedBooks;

  getBookTitles() : string[] {
    return this.selectedBooks().map(book => book.title ?? '');
  }

  onRemoveBook(title: string) {
    this.bookSelectionService.removeBookByTitle(title);
  }
}
