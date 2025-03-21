import { Pipe, PipeTransform } from '@angular/core';
import { Book } from '../../../shared/models/book';

@Pipe({
  name: 'bookToString',
})
export class BookToStringPipe implements PipeTransform {
  transform(book: Book): string {
    return `${book.id} - ${book.author} : ${book.title} (${book.publicationDate?.getFullYear()})`;
  }
}