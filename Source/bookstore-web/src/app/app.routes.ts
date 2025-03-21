import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        loadComponent: () => import('./layout/book-details/book-details.component').then(m => m.BookDetailsComponent)
    },
    {
        path: 'add-new',
        pathMatch: 'full',
        loadComponent: () => import('./features/bookstore/add-new-book/add-new-book.component').then(m => m.AddNewBookComponent)
    }
];
