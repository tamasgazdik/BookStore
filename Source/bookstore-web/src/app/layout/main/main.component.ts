import { Component, inject, input, output, signal } from '@angular/core';
import { BookListComponent } from "../book-list/book-list.component";
import { Book } from '../../shared/models/book';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-main',
  imports: [BookListComponent, RouterOutlet],
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent {
  selectedBooks = signal<Book[]>([]);
  router = inject(Router);

  onBookSelected() {
    this.router.navigate(['/']);
  }

  onNewBookSelected() {
    this.router.navigate(['/add-new']);
  }
}
