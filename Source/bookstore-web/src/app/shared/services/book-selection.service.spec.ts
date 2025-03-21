import { TestBed } from '@angular/core/testing';

import { BookSelectionService } from './book-selection.service';

describe('BookSelectionService', () => {
  let service: BookSelectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookSelectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
