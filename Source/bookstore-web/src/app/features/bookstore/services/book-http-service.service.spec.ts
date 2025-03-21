import { TestBed } from '@angular/core/testing';

import { BookHttpService } from './book-http-service.service';

describe('BookhttpserviceService', () => {
  let service: BookHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
