import { BookToStringPipe } from './book-to-string.pipe';

describe('BookToStringPipe', () => {
  it('create an instance', () => {
    const pipe = new BookToStringPipe();
    expect(pipe).toBeTruthy();
  });
});
