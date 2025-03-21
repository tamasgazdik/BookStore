import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedBooksTagsComponent } from './selected-books-tags.component';

describe('SelectedBooksTagsComponent', () => {
  let component: SelectedBooksTagsComponent;
  let fixture: ComponentFixture<SelectedBooksTagsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectedBooksTagsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectedBooksTagsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
