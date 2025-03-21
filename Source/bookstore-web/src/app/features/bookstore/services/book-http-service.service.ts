import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Book } from '../../../shared/models/book';
import { map, Observable, retry } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookHttpService {
  constructor() {}

  httpClient = inject(HttpClient);

  getBooks() {
    return (
      this.httpClient
        .get<Book[]>('https://localhost:8081/api/v1/books')
        .pipe(retry({ count: 10, delay: 1000 }))
    );
  }

  addBook(book: Book): Observable<number> {
    return new Observable((observer) => {
      this.httpClient
        .post('https://localhost:8081/api/v1/books', book, {
          observe: 'response',
        })
        .subscribe({
          next: (response) => {
            observer.next(response.status);
            observer.complete();
          },
          error: (error) => {
            observer.error(error.status);
          },
        });
    });
  }
}
