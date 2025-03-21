import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-selected-books-tags',
  imports: [],
  templateUrl: './selected-books-tags.component.html',
  styleUrl: './selected-books-tags.component.scss'
})
export class SelectedBooksTagsComponent {
  selectedBookTitles = input<string[]>();
  bookToRemove = output<string>();

  removeBook(title: string) {
    this.bookToRemove.emit(title);
  }
}
