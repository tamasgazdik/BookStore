import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from '../../../shared/models/book';
import { BookHttpService } from '../services/book-http-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-new-book',
  imports: [FormsModule, CommonModule],
  templateUrl: './add-new-book.component.html',
  styleUrl: './add-new-book.component.scss',
})
export class AddNewBookComponent {
  book: Book = { title: '', author: '', publicationDate: new Date() };
  message: string = '';
  isSuccess: boolean = false;
  today: string = new Date().toISOString().split('T')[0]; // Get today's date in YYYY-MM-DD format

  constructor(
    private bookHttpService: BookHttpService,
    private router: Router
  ) {}

  navigateBack() {
    this.router.navigate(['/']);
  }

  onSubmit() {
    console.log('onSubmit called successfully');
    if (!this.book.title || !this.book.author || !this.book.publicationDate) {
      return;
    }

    this.bookHttpService.addBook(this.book).subscribe({
      next: (statusCode: number) => {
        if (statusCode === 201) {
          this.message = 'Book added successfully!';
          this.isSuccess = true;

          // Reset form after success
          this.book = { title: '', author: '', publicationDate: new Date() };

          // Redirect back after a short delay
          setTimeout(() => this.router.navigate(['/']), 1500);
        } else {
          this.message = `Unexpected response: ${statusCode}`;
          this.isSuccess = false;
        }
      },
      error: (errorStatus: number) => {
        this.message = `Error: Could not add book (Status Code: ${errorStatus})`;
        this.isSuccess = false;
      },
    });
  }
}
