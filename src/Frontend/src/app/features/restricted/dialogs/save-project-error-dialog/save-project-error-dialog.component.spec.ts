import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveProjectErrorDialogComponent } from './save-project-error-dialog.component';

describe('SaveProjectErrorDialogComponent', () => {
  let component: SaveProjectErrorDialogComponent;
  let fixture: ComponentFixture<SaveProjectErrorDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SaveProjectErrorDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SaveProjectErrorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
